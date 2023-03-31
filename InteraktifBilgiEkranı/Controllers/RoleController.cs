using BusinessLayer.Concrete;
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
        [Authorize]
        public ActionResult Index()
        {
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
    }
}