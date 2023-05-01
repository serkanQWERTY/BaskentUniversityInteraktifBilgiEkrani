using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using InteraktifBilgiEkranı.Controllers;

namespace InteraktifBilgiEkranı.Controllers
{
    public class NewController : Controller
    {
        NewManager Nm = new NewManager(new EfNewDAL());
        TvManager Tm = new TvManager(new EfTvDAL());
        UserManager Um = new UserManager(new EfUserDAL());
        private Context db = new Context();

        // GET: Sliders
        [Authorize(Roles="ADM,CAD,SEK,İDP")]
        public ActionResult Index()
        {
            var newValues = Nm.GetList();
            return View(newValues);
        }

        [HttpGet]
        public ActionResult AddNew()
        {

            List<SelectListItem> valueTv = (from x in Tm.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.TvDescription,
                                                Value = x.TvID.ToString()
                                            }
                            ).ToList();
            List<SelectListItem> valueUser = (from x in Um.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName + " " + x.UserSurname,
                                                  Value = x.UserID.ToString()

                                              }
                                              ).ToList();
            ViewBag.vlt = valueTv;
            ViewBag.vlu = valueUser;
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(New p,int id=0)
        {
            string k = (string)Session["UserMail"];
            id = db.Users.Where(x => x.UserMail == k).Select(y => y.UserID).FirstOrDefault();

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.NewPath = "/Image/" + dosyaadi + uzanti;
            }

            p.NewCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UserID = id;

            Nm.NewAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditNew(int id)
        {
            List<SelectListItem> valueTv = (from x in Tm.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.TvDescription,
                                                Value = x.TvID.ToString()
                                            }
                                             ).ToList();
            List<SelectListItem> valueUser = (from x in Um.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName + " " + x.UserSurname,
                                                  Value = x.UserID.ToString()

                                              }
                                              ).ToList();
            ViewBag.vlt = valueTv;
            ViewBag.vlu = valueUser;
            var newValues = Nm.GetByID(id);
            return View(newValues);
        }

        [HttpPost]
        public ActionResult EditNew(New p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.NewPath = "/Image/" + dosyaadi + uzanti;
            }
            Nm.NewUpdate(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteNew(int id)
        {
            var newValues = Nm.GetByID(id);
            Nm.NewDelete(newValues);
            return RedirectToAction("Index");
        }
        
        public ActionResult ChangeStatusNew(int id)
        {
            var newValues = Nm.GetByID(id);
            Nm.NewChangeStatus(newValues);
            return RedirectToAction("Index");
        }

        public ActionResult ReportNew()
        {
            ViewBag.title = "Haber Raporlama Sayfası";
            var newValues = Nm.GetList();
            return View(newValues);
        }
    }
}