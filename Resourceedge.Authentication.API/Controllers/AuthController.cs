using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resourceedge.Authentication.Domain.Interfaces;
using Resourceedge.Authentication.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Authentication.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthInterface AuthRepo;
        private readonly IIdentityServerInteractionService interactionService;
        public AuthController(IAuthInterface auth, IIdentityServerInteractionService _interactionService)
        {
            this.AuthRepo = auth;
            interactionService = _interactionService;
        }

        public IActionResult VerifyEmail(string ReturnUrl)
        {
            ViewBag.Title = "Verify Email";
            return View(new VerifyEmail { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmail model)
        {
            ViewBag.Title = "Verify Email";

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Email is required";
                return View(model);
            }
            var result = await AuthRepo.GetUserbyEmailAsync(model.Email);
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
            ViewBag.Title = "Authenticate";

            TempData.TryGetValue("LoginModel", out object savedTempObject);
            if (savedTempObject == null)
            {
                return RedirectToAction("VerifyEmail", new { ReturnUrl });
            }

            var loginModel = JsonConvert.DeserializeObject<LoginGetViewModel>((string)savedTempObject);
            return View(new LoginViewModel { ReturnUrl = ReturnUrl, UserName = loginModel.UserName, Name = loginModel.Name });
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel model)
        {
            ViewBag.Title = "Authenticate";

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "password is required";
                return View(model);
            }
            var result = await AuthRepo.Login(model);
            if (!result.Item1)
            {
                ViewBag.Error = "Username or password incorrect";
                return View(model);
            }

            var claims = User.Claims.ToList();
            return Redirect(model.ReturnUrl);
        }

        public IActionResult ResetPassword(string Username, string Token, string ReturnUrl)
        {
            ViewBag.Title = "Reset Password";

            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Token))
            {
                return RedirectToAction("PasswordReset", new { ReturnUrl });
            }

            return View(new ResetPasswordViewModel { Email = Username, Token = Token });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            ViewBag.Title = "Reset Password";
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "password is required";
                return View(model);
            }

            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "Password and Confirm Password must match";
                return View(model);
            }

            var result = await AuthRepo.ResetUserPassword(model);
            if (!result)
            {
                ViewBag.Error = "Password Failed to reset, Try Again";
            }


            return RedirectToAction("VerifyEmail", new { ReturnUrl = "" });

        }

        public IActionResult PasswordReset(string ReturnUrl)
        {
            ViewBag.Title = "Password Reset";

            return View(new VerifyEmail { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(VerifyEmail model)
        {
            ViewBag.Title = "Password Reset";

            if (!ModelState.IsValid)
            {
                return RedirectToAction("PasswordReset", new { ReturnUrl = "" });
            }

            var isEmailInDb =await AuthRepo.GetUserbyEmailAsync(model.Email);
            if(!isEmailInDb.Item1)
            {
                ViewBag.Error = isEmailInDb.Item2;
                return RedirectToAction("PassordReset", new { ReturnUrl = "" });
            }

            var result = await AuthRepo.GetResetPasswordToken(model.Email);
            if (!result.Item1)
            {
                ViewBag.Error = "Email does not exist, Please Enter registered Email";
            }

            var callbackUrl = UrlHelperExtensions.ActionLink(this.Url, "ResetPassword", "Auth", new { Username = result.Item2.Email, Token = result.Item3, ReturnUrl = model.ReturnUrl });
            var res = await AuthRepo.SendResetPasswordEmail(result.Item2, callbackUrl);

            if (!res.Item1)
            {
                ViewBag.Error = "Email Failed to send";
            }

            ViewBag.Success = "Email Sent Successfully";
            return View(new VerifyEmail { ReturnUrl = model.ReturnUrl });
        }

        [HttpGet]
        public async Task<IActionResult> Signout(string logoutId)
        {
            await AuthRepo.LogoutUser();
            var logoutRequest = await interactionService.GetLogoutContextAsync(logoutId);
             if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(logoutRequest.PostLogoutRedirectUri); 
        }
    }
}
