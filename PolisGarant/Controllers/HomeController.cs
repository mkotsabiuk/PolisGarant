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

        public IActionResult Contacts(string serviceType)
        {
            switch (serviceType)
            {
                case "standart":
                    ViewBag.Message = "Мене зацікавило страхування \"Стандарт\". Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "complex":
                    ViewBag.Message = "Мене зацікавило комплексне страхування. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "travel":
                    ViewBag.Message = "Мене зацікавило туристичне страхування. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "car":
                    ViewBag.Message = "Мене зацікавило автострахування. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "property":
                    ViewBag.Message = "Мене зацікавило страхування житла та нерухомості. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "document":
                    ViewBag.Message = "Мене зацікавила нострифікація документів. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "job":
                    ViewBag.Message = "Мене зацікавило працевлаштування в Чехії. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                case "certificates":
                    ViewBag.Message = "Мене зацікавили довідки про несудимість з Польщі. Прошу зв'язатися зі мною для подальшої взаємодії.";
                    break;
                default:
                    ViewBag.Message = "";
                    break;
            }
            ViewBag.Tab = "Contacts";
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(string name, string email, string message, string number)
        {
            var messageForSending = new MimeMessage();
            messageForSending.From.Add(new MailboxAddress("Site PolisGarant", "polisgarant@email.cz"));
            messageForSending.To.Add(new MailboxAddress("PolisGarant", "polisgarant@email.cz"));
            messageForSending.To.Add(new MailboxAddress("PolisGarant", "tysdrib@ukr.net"));
            messageForSending.Subject = "PolisGarant purchase";
            message = $"User {name}  {email} {number} sent you a message:\n\n" + message;
            messageForSending.Body = new TextPart("plain")
            {
                Text = message
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.seznam.cz", 465, true);
                    client.Authenticate("polisgarant@email.cz", "pg2019");
                    client.Send(messageForSending);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                return View(@"~/Views/Home/Contacts.cshtml");
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
