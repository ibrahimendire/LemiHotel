using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Controllers
{
    public class AddEmployee : Controller
    {
       /* [Authorize]*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
