using BusinessLayer.Concrete;
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
        // GET: Department
        [Authorize(Roles="ADM")]//Sadece ADM bu sayfayı görüntüleyebilir.
        public ActionResult Index()
        {
            var departmentValues = Dm.GetList();
            return View(departmentValues);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
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
            p.DepartmentCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            Dm.DepartmentAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDepartment(int id)
        {
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