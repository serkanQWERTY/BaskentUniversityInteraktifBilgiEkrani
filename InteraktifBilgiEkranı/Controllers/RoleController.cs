using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class RoleController : Controller
    {
        // GET: Faculty
        RoleManager Rm = new RoleManager(new EfRoleDAL());
        UserManager Um = new UserManager(new EfUserDAL());
        Context c = new Context();

        [Authorize(Roles="ADM")]
        public ActionResult Index()
        {
            string p = (string)Session["UserMail"];
            int id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            string path = userValues.UserPath;
            TempData["Path"] = path;

            var facultyValues = Rm.GetList();
            return View(facultyValues);
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role p)
        {
                Rm.RoleAdd(p);
                return RedirectToAction("Index");

        }

        public ActionResult DeleteRole(int id)
        {
            var roleValues = Rm.GetByID(id);
            Rm.RoleDelete(roleValues);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatusRole(int id)
        {
            var roleValues = Rm.GetByID(id);
            Rm.RoleChangeStatus(roleValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditRole(int id)
        {
            var roleValues = Rm.GetByID(id);
            return View(roleValues);
        }

        [HttpPost]
        public ActionResult EditRole(Role p)
        {
            Rm.RoleUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult ReportRole()
        {
            ViewBag.title = "Yetkinlik Raporlama Sayfası";
            var facultyValues = Rm.GetList();
            return View(facultyValues);
        }
    }
}