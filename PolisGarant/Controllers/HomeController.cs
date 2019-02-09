using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolisGarant.Models;

namespace PolisGarant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Tab = "About";
            return View();
        }

        public IActionResult Purchase()
        {
            ViewBag.Tab = "Purchase";
            return View();
        }

        public IActionResult Contacts()
        {
            ViewBag.Tab = "Contacts";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
