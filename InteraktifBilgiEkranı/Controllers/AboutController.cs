using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class AboutController : Controller
    {
        UserManager Um = new UserManager(new EfUserDAL());
        Context c = new Context(); 
        // GET: About
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            string p = (string)Session["UserMail"];
            int id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            string path = userValues.UserPath;
            TempData["Path"] = path;
            return View(userValues);
        }
        
        //public ActionResult Contact()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Contact(string name = null, string email = null, string subject = null, string message = null)
        //{
        //    if (name != null && email != null)
        //    {
        //        WebMail.SmtpServer = "smtp.gmail.com";
        //        WebMail.EnableSsl = true;
        //        WebMail.UserName = "baskentbilgiekrani@gmail.com";
        //        WebMail.Password = "ntxrkkvzavktxqqe";
        //        WebMail.SmtpPort = 587;
        //        WebMail.Send("serkan.isde99@gmail.com", subject, email + "<br/>" + message);
        //        ViewBag.uyarı = "Mesajınız Başarıyla Gönderilmiştir!";
        //    }
        //    else
        //    {
        //        ViewBag.uyarı = "Hata Oluştu. Tekrar Dene.";
        //    }
        //    return View();
        //}


    }
}