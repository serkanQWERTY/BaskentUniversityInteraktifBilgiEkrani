using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class SendTicketController : Controller
    {
        // GET: SendTicket
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string NameSurname = null, string Email = null, string Subject = null, string Message = null)
        {

            if (NameSurname != null && Email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "baskentbilgiekrani@gmail.com";
                WebMail.Password = "ntxrkkvzavktxqqe";
                WebMail.SmtpPort = 587;
                WebMail.Send("baskentbilgiekrani@gmail.com", Subject, Email + "<br/>"+ NameSurname +"<br/> Mesaj:" + Message);
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";
                return RedirectToAction("ConfirmSendTicket","SendTicket");
            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            }
            return View();
        }

        public ActionResult ConfirmSendTicket()
        {
            return View();
        }
    }
}