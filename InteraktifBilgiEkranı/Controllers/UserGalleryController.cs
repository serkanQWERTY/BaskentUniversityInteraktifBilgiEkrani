using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class UserGalleryController : Controller
    {
        UserManager Um = new UserManager(new EfUserDAL());
        NewManager Nm = new NewManager(new EfNewDAL());
        Context c = new Context();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            string p = (string)Session["UserMail"];
            int id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            string path = userValues.UserPath;
            TempData["Path"] = path;

            var usergalleryinfos = Um.GetList();
            return View(usergalleryinfos);
        }

        [HttpGet]
        [Authorize]
        public ActionResult NewByUser(int id)
        {
            string p = (string)Session["UserMail"];
            int idd = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(idd);
            string path = userValues.UserPath;
            TempData["Path"] = path;

            var newValues = Nm.GetListByUserID(id);
            return View(newValues);
        }
    }
}