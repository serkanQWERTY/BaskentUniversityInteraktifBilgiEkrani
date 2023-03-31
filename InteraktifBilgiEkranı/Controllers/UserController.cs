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
    public class UserController : Controller
    {
        UserManager Um = new UserManager(new EfUserDAL());
        RoleManager Rm = new RoleManager(new EfRoleDAL());
        DepartmentManager Dm = new DepartmentManager(new EfDepartmentDAL());
        FacultyManager Fm = new FacultyManager(new EfFacultyDAL());
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var userValues = Um.GetList();
            return View(userValues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            List<SelectListItem> valueRole = (from x in Rm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.RoleName,
                                                     Value = x.RoleID.ToString()
                                                 }
                                                ).ToList();
            List<SelectListItem> valueDepartment = (from x in Dm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmentName,
                                                     Value = x.DepartmentID.ToString()
                                                 }
                                                ).ToList();
            List<SelectListItem> valueFaculty = (from x in Fm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.FacultyName,
                                                     Value = x.FacultyID.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vlr = valueRole;
            ViewBag.vld = valueDepartment;
            ViewBag.vlf = valueFaculty;
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User p)
        {
            p.UserCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            Um.UserAdd(p);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            List<SelectListItem> valueRole = (from x in Rm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleID.ToString()
                                              }
                                                  ).ToList();
            List<SelectListItem> valueDepartment = (from x in Dm.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.DepartmentName,
                                                        Value = x.DepartmentID.ToString()
                                                    }
                                                ).ToList();
            List<SelectListItem> valueFaculty = (from x in Fm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.FacultyName,
                                                     Value = x.FacultyID.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vlr = valueRole;
            ViewBag.vld = valueDepartment;
            ViewBag.vlf = valueFaculty;
            var userValues = Um.GetByID(id);
            return View(userValues);
        }

        [HttpPost]
        public ActionResult EditUser(User p)
        {
            Um.UserUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id)
        {
            var userValues = Um.GetByID(id);
            Um.UserDelete(userValues);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatusUser(int id)
        {
            var userValues = Um.GetByID(id);
            Um.UserChangeStatus(userValues);
            return RedirectToAction("Index");
        }
    }
}