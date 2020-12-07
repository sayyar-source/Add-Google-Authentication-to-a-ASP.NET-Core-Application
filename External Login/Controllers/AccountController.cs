
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace External_Login.Controllers
{
    [Route("account")]
    [Authorize]
    public class AccountController : Controller
    {
  
        public IActionResult Index()
        {
            return View();
        }
  

        [Route("google-login")]
        [AllowAnonymous]
        public IActionResult GoogleLogin(string returnUrl = null)
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
           
        }
        [Route("google-response")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claim = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.Type,
                    claim.OriginalIssuer,
                    claim.Value

                });
           // return RedirectToAction("Privacy", "home");
        return Json(claim);
        }
     
         [Route("logout")]
         [Authorize]
        public async Task<IActionResult> Logout()
        
        
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
