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
    public class FacultyController : Controller
    {
        // GET: Faculty
        FacultyManager Fm = new FacultyManager(new EfFacultyDAL());
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

            var facultyValues = Fm.GetList();
            return View(facultyValues);
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public ActionResult EditFaculty(int id)
        {
            var facultyValues = Fm.GetByID(id);
            return View(facultyValues);
        }

        [HttpPost]
        public ActionResult EditFaculty(Faculty p)
        {
            p.FacultyStatus = true;
            Fm.FacultyUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult ReportFaculty()
        {
            ViewBag.title = "Fakülte Raporlama Sayfası";
            var facultyValues = Fm.GetList();
            return View(facultyValues);
        }
    }
}