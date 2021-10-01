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
            ViewBag.Tab = "Services";
            return View();
        }

        public IActionResult CarInsurance()
        {
            ViewBag.Tab = "Services";
            return View();
        }
        public IActionResult ComplexInsurance()
        {
            ViewBag.Tab = "Services";
            return View();
        }
        public IActionResult Diploma()
        {
            ViewBag.Tab = "Services";
            return View();
        }

        public IActionResult PropertyInsurance()
        {
            ViewBag.Tab = "Services";
            return View();
        }

        public IActionResult StandardInsurance()
        {
            ViewBag.Tab = "Services";
            return View();
        }

        public IActionResult TravelInsurance()
        {
            ViewBag.Tab = "Services";
            return View();
        }

        public IActionResult Certificates()
        {
            ViewBag.Tab = "Services";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

