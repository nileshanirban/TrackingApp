using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerApp.Controllers
{
    public class LandingController: Controller
    {
        public IActionResult DefaultLand()
        {
            if (User.Identity.IsAuthenticated)
            {

            }
            return View();
        }
    }
}
