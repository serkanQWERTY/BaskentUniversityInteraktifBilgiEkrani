using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
            DepartmentValidator departmentValidator = new DepartmentValidator();
            ValidationResult results = departmentValidator.Validate(p);
            p.DepartmentCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (results.IsValid)
            {
                Dm.DepartmentAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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
        public ActionResult DeleteDepartment(int id)
        {
            var departmentValues = Dm.GetByID(id);
            departmentValues.DepartmentStatus = false;
            Dm.DepartmentDelete(departmentValues);
            return RedirectToAction("Index");
        }

    }
}