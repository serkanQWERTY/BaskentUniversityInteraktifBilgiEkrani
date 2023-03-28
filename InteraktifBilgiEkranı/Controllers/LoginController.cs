using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var infos = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail &&
            x.UserPassword == p.UserPassword);

            if (infos != null)
            {
                FormsAuthentication.SetAuthCookie(infos.UserMail,false);
                Session["UserMail"] = infos.UserMail;
                return RedirectToAction("Index", "Faculty");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
    }
}