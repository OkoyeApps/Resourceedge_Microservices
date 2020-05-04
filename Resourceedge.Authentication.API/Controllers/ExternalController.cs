using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resourceedge.Authentication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Resourceedge.Authentication.API.Utils;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Resourceedge.Authentication.API.Controllers
{
    //[ApiController]
    //[Authorize]
    [Route("api/auth/external")]
    public class ExternalController : Controller
    {
        private readonly IExternalServiceInterface externalRepo;

        public ExternalController(IExternalServiceInterface _externalRepo)
        {
            externalRepo = _externalRepo ?? throw new ArgumentNullException(nameof(_externalRepo));
        }


        //Write the model binder for this later to accept [ModelBinder(BinderType =typeof(DictionaryModelBinder))] Dictionary<string, IEnumerable<Claim>> usersAndClaims

        [ReadRequestBodyIntoItems]
        [HttpPost]
        public async Task<IActionResult> AddClaimsToUsersByEmail()
        {
            Dictionary<string, IEnumerable<Claim>> usersAndClaims = new Dictionary<string, IEnumerable<Claim>>();
            using (var reader = new StreamReader(Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            {
                var bodyString = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(bodyString))
                {
                    usersAndClaims = JsonSerializer.Deserialize<Dictionary<string, IEnumerable<Claim>>>(bodyString);
                }

            }
            if (usersAndClaims.Any())
            {
                var result = await externalRepo.AddMultipleUserClaimsByEmail(usersAndClaims);
                if (!result)
                {
                    return BadRequest(new { Errors = "Could not add one or more claims for supervisors" });
                }

            }
            return Ok();
        }
    }
}
