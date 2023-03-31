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
    public class FacultyController : Controller
    {
        // GET: Faculty
        FacultyManager Fm = new FacultyManager(new EfFacultyDAL());
        [Authorize]
        public ActionResult Index()
        {
            var facultyValues = Fm.GetList();
            return View(facultyValues);
        }

        [HttpGet]
        public ActionResult AddFaculty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFaculty(Faculty p)
        {
            Fm.FacultyAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFaculty(int id)
        {
            var facultyValues = Fm.GetByID(id);
            Fm.FacultyDelete(facultyValues);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeStatusFaculty(int id)
        {
            var facultyValues = Fm.GetByID(id);
            Fm.FacultyChangeStatus(facultyValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditFaculty(int id)
        {
            var facultyValues = Fm.GetByID(id);
            return View(facultyValues);
        }

        [HttpPost]
        public ActionResult EditFaculty(Faculty p)
        {
            Fm.FacultyUpdate(p);
            return RedirectToAction("Index");
        }
    }
}