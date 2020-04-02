using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resourceedge.Authentication.Domain.Interfaces;
using Resourceedge.Authentication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthInterface AuthRepo;

        public AuthController(IAuthInterface auth)
        {
            this.AuthRepo = auth;
        }

        public IActionResult VerifyEmail(string ReturnUrl)
        {
            return View(new VerifyEmail { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmail model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = "Email is required";
                return View(model);
            }
            var result = await AuthRepo.GetUserbyEmail(model.Email);
            if (!result.Item1)
            {
                ViewData["error"] = result.Item2;
                return View(model);
            }
            var TempObject = JsonConvert.SerializeObject(new LoginGetViewModel { UserName = model.Email, ReturnUrl = model.ReturnUrl, Name = result.Item2 });
            TempData["LoginModel"] = TempObject;
            return RedirectToAction("Authenticate", new { ReturnUrl = model.ReturnUrl });
        }

        public IActionResult Authenticate(string ReturnUrl)
        {
            TempData.TryGetValue("LoginModel", out object savedTempObject);
            if (savedTempObject == null)
            {
                return RedirectToAction("VerifyEmail", new { ReturnUrl });
            }

            var loginModel = JsonConvert.DeserializeObject<LoginGetViewModel>((string)savedTempObject);
            return View(new LoginViewModel { ReturnUrl = ReturnUrl, UserName = loginModel .UserName, Name = loginModel.Name});
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel model)
        {
            var result = await AuthRepo.Login(model);
            if (!result.Item1)
            {
                return View(model);
            }

            var claims = User.Claims.ToList();
                return Redirect(model.ReturnUrl);
        }
    }
}
