using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult First()
        {
            return View();
        }
    }
}
