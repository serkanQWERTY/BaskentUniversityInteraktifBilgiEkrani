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
            if (infos.UserMail == p.UserMail && infos.UserPassword == Crypto.Hash(p.UserPassword, "MD5"))
            {
                //2li dogrulamaya gidecek
                FormsAuthentication.SetAuthCookie(infos.UserMail, false);
                Session["UserMail"] = infos.UserMail;
                return RedirectToAction("Index", "About");
            }
            else
            {
                ViewBag.uyarı = "Kullanıcı adı veya Şifre Yanlış";
                return RedirectToAction("Index");
            }
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
            User user = new User();

            var mail = c.Users.Where(x => x.UserMail == usermail).SingleOrDefault();

            if (mail != null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);

                mail.UserPassword = Crypto.Hash(Convert.ToString(finalString), "MD5");
                c.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "baskentbilgiekrani@gmail.com";
                WebMail.Password = "ntxrkkvzavktxqqe";
                WebMail.SmtpPort = 587;
                WebMail.Send(usermail, "Şifre Sıfırlama İşlemi", "Merhaba " + mail.UserName + "," + "<br/>" + " <br/> Yeni şifreniz: " + finalString + " olarak belirlenmiştir." + "<br/> İyi günler dileriz.");
            }
            return RedirectToAction("ConfirmResetPassword","Login");
        }

        public ActionResult ConfirmResetPassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}