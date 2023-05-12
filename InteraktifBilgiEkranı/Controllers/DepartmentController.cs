using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager Dm = new DepartmentManager(new EfDepartmentDAL());
        FacultyManager Fm = new FacultyManager(new EfFacultyDAL());
        UserManager Um = new UserManager(new EfUserDAL());
        Context c = new Context();

        [HttpGet]
        [Authorize(Roles="ADM")]//Sadece ADM bu sayfayı görüntüleyebilir.
        public ActionResult Index()
        {
            string p = (string)Session["UserMail"];
            int id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            string path = userValues.UserPath;
            TempData["Path"] = path;

            var departmentValues = Dm.GetList();
            return View(departmentValues);
        }

        [HttpGet]
        [Authorize(Roles = "ADM")]
        public ActionResult AddDepartment()
        {
            string p = (string)Session["UserMail"];
            int id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            string path = userValues.UserPath;
            TempData["Path"] = path;
            List<SelectListItem> valueFaculty = (from x in Fm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.FacultyName,
                                                     Value = x.FacultyID.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vlf = valueFaculty;
            return View();
        }

        [HttpPost]

        public ActionResult AddDepartment(Department p)
        {
            Dm.DepartmentAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "ADM")]
        public ActionResult EditDepartment(int id)
        {
            string p = (string)Session["UserMail"];
            int idd = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(idd);
            string path = userValues.UserPath;
            TempData["Path"] = path;
            List<SelectListItem> valueFaculty = (from x in Fm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.FacultyName,
                                                     Value = x.FacultyID.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vlf = valueFaculty;
            var departmentValues = Dm.GetByID(id); 
            return View(departmentValues);
        }

        [HttpPost]
        public ActionResult EditDepartment(Department p)
        {
            p.DepartmentStatus = true;
            Dm.DepartmentUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatusDepartment(int id)
        {
            var departmentValues = Dm.GetByID(id);
            Dm.DepartmentChangeStatus(departmentValues);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var departmentValues = Dm.GetByID(id);
            Dm.DepartmentDelete(departmentValues);
            return RedirectToAction("Index");
        }

        public ActionResult ReportDepartment()
        {
            ViewBag.title = "Bölüm Raporlama Sayfası";
            var departmentValues = Dm.GetList();
            return View(departmentValues);
        }
    }
}