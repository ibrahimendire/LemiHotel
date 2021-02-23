using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult HelpForm()
        {
            return View();
        }
    }
}
