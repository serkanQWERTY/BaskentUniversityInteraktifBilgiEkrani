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
    public class TvController : Controller
    {
        TvManager Tm = new TvManager(new EfTvDAL());
        DepartmentManager Dm = new DepartmentManager(new EfDepartmentDAL());
        UserManager Um = new UserManager(new EfUserDAL());
        Context c = new Context();
        // GET: Department
        [Authorize(Roles="ADM,TEK")]
        public ActionResult Index()
        {
            string p = (string)Session["UserMail"];
            int id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            string path = userValues.UserPath;
            TempData["Path"] = path;

            var tvValues = Tm.GetList();
            return View(tvValues);
        }

        [HttpGet]
        public ActionResult AddTv()
        {
            List<SelectListItem> valueDepartment = (from x in Dm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmentName,
                                                     Value = x.DepartmentID.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vld = valueDepartment;
            return View();
        }

        [HttpPost]
        public ActionResult AddTv(Tv p)
        {
            p.TvCreationDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            Tm.TvAdd(p);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditTv(int id)
        {
            List<SelectListItem> valueDepartment = (from x in Dm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmentName,
                                                     Value = x.DepartmentID.ToString()
                                                 }
                                                  ).ToList();
            ViewBag.vld = valueDepartment;
            var tvValues = Tm.GetByID(id);
            return View(tvValues);
        }
        [HttpPost]
        public ActionResult EditTv(Tv p)
        {
            Tm.TvUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTv(int id)
        {
            var tvValues = Tm.GetByID(id);
            Tm.TvDelete(tvValues);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatusTv(int id)
        {
            var tvValues = Tm.GetByID(id);
            Tm.TvChangeStatus(tvValues);
            return RedirectToAction("Index");
        }

        public ActionResult ReportTv()
        {
            ViewBag.title = "Ekran Raporlama Sayfası";
            var tvValues = Tm.GetList();
            return View(tvValues);
        }
    }
}