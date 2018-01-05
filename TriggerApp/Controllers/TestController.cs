using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerApp.Controllers
{
    public class TestController : Controller
    {
        [Authorize]     
        public IActionResult Index()
        {            
            return View();                           
        }

        [Authorize]
        public IActionResult AuthSignOut()
        {
            var callBackURI = Url.Action("DefaultLand", "Landing");
            if (User.Identity.IsAuthenticated)
            {
                return SignOut(new AuthenticationProperties() { RedirectUri = callBackURI },
                    new string[] { CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme });
            }
            return View();
        }
    }
}
