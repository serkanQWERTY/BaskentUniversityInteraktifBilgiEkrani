using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace InteraktifBilgiEkranı.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User p)
        {
            Context c = new Context();
            var infos = c.Users.Where(x => x.UserMail == p.UserMail).SingleOrDefault();
            if(infos.UserMail==p.UserMail && infos.UserPassword == Crypto.Hash(p.UserPassword, "MD5"))
            {
                FormsAuthentication.SetAuthCookie(infos.UserMail, false);
                Session["UserMail"] = infos.UserMail;
                return RedirectToAction("Index", "About");
            }
            else
            {
                //ViewBag.uyarı = "Kullanıcı adı veya Şifre Yanlış";
                return RedirectToAction("Index");
            }
            
            //Context c = new Context();
            //var infos = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail &&
            //x.UserPassword == p.UserPassword);

            //if (infos != null)
            //{
            //    FormsAuthentication.SetAuthCookie(infos.UserMail,false);
            //    Session["UserMail"] = infos.UserMail;
            //    return RedirectToAction("Index", "About");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }

        [HttpGet]
        public ActionResult ForgotMyPassword()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ForgotMyPassword(string usermail)
        {
            Context c = new Context();
            var mail = c.Users.Where(x => x.UserMail == usermail).SingleOrDefault();

            if (mail != null)
            {
                Random rnd = new Random();
                int newpassword = rnd.Next();

                User user = new User();

                //mail.UserPassword = sifrelecoz.sifrele(usermail, Convert.ToString(newpassword));
                mail.UserPassword = Crypto.Hash(Convert.ToString(newpassword), "MD5");
                c.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "baskentbilgiekrani@gmail.com";
                WebMail.Password = "ntxrkkvzavktxqqe";
                WebMail.SmtpPort = 587;
                WebMail.Send(usermail, "Şifre Sıfırlama İşlemi", "Merhaba " + mail.UserName + mail.UserSurname+"," + " <br/> yeni şifreniz: " + newpassword + " olarak belirlenmiştir." + "<br/> İyi günler dileriz.");
                ViewBag.Uyari = "Mesajınız Başarı ile gönderilmiştir.";
            }
            else
            {
                ViewBag.Uyari = "Hata oluştu. Tekrar Deneyiniz:";
            }
            return View();
        }

        public ActionResult ConfirmResetPassword()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            //Session["UserID"] = null;
            Session["UserMail"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Index");
        }

    }
}