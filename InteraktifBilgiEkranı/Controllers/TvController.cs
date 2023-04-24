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
    public class TvController : Controller
    {
        TvManager Tm = new TvManager(new EfTvDAL());
        DepartmentManager Dm = new DepartmentManager(new EfDepartmentDAL());
        // GET: Department
        [Authorize(Roles="ADM,TEK")]
        public ActionResult Index()
        {
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