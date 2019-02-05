using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolisGarant.Models;

namespace PolisGarant.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Career()
        {
            return View();
        }

        public IActionResult CarInsurance()
        {
            return View();
        }
        public IActionResult ComplexInsurance()
        {
            return View();
        }
        public IActionResult Diploma()
        {
            return View();
        }

        public IActionResult PropertyInsurance()
        {
            return View();
        }

        public IActionResult StandardInsurance()
        {
            return View();
        }
        public IActionResult TravelInsurance()
        {
            return View();
        }

        public IActionResult Certificates()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

