using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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

        [HttpPost]
        public IActionResult SendMessage(string name, string email, string message)
        {
            var messageForSending = new MimeMessage();
            messageForSending.From.Add(new MailboxAddress(name, email));
            messageForSending.To.Add(new MailboxAddress("Site PolisGarant", "polisgarant@email.cz"));
            messageForSending.Subject = "PolisGarant purchase";
            messageForSending.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("polisgarant.cz@gmail.com", "polisgarant.cz2019");
                client.Send(messageForSending);
                client.Disconnect(true);
            }

            return View(@"~/Views/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
