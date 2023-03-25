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
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        public ActionResult Index()
        {
            var newValues = Nm.GetList();
            return View(newValues);
            //return View(db.News.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        [HttpGet]
        // GET: Sliders/Create
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
        public ActionResult AddNew(New p)
        {
            //NewValidator newValidator = new NewValidator();
            //ValidationResult results = newValidator.Validate(p);

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.NewPath = "/Image/" + dosyaadi + uzanti;
            }
            p.NewCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //if (results.IsValid)
            //{
            Nm.NewAdd(p);
            return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();

        }
        //////[HttpPost]
        //////[ValidateAntiForgeryToken]
        //////public ActionResult AddNew([Bind(Include = "SliderId,Baslik,Aciklama,ResimURL")] New news, HttpPostedFileBase ResimURL)
        //////{
        //////    news.NewCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //////    if (ModelState.IsValid)

        //////    {
        //////        if (ResimURL != null)
        //////        {
        //////            WebImage img = new WebImage(ResimURL.InputStream);
        //////            FileInfo imginfo = new FileInfo(ResimURL.FileName);

        //////            string newsimage = Guid.NewGuid().ToString() + imginfo.Extension;
        //////            img.Resize(1024, 360);
        //////            img.Save("~/Uploads/Slider/" + newsimage);

        //////            news.NewPath = "/Uploads/Slider/" + newsimage;
        //////        }
        //////        db.News.Add(news);
        //////        db.SaveChanges();
        //////        return RedirectToAction("Index");
        //////    }

        //////    return View(news);
        //////}
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
            var userValue = Um.GetByID(id);
            return View(userValue);
        }
        [HttpPost]
        public ActionResult EditNew(New p)
        {
            Nm.NewUpdate(p);
            return RedirectToAction("Index");
        }

        // GET: Sliders/Edit/5
        //public ActionResult EditNew(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    New news = db.News.Find(id);
        //    if (news == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(news);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditNew([Bind(Include = "NewID,NewName,NewCreationDate,İçerik,NewStatus,NewDescription,UserID,TvID")] 
        //New news, HttpPostedFileBase İçerik, int id)
        //{
        //    List<SelectListItem> valueTv = (from x in tm.GetList()
        //                                    select new SelectListItem
        //                                    {
        //                                        Text = x.TvDescription,
        //                                        Value = x.TvID.ToString()
        //                                    }
        //                                     ).ToList();
        //    List<SelectListItem> valueUser = (from x in um.GetList()
        //                                      select new SelectListItem
        //                                      {
        //                                          Text = x.UserName + " " + x.UserSurname,
        //                                          Value = x.UserID.ToString()

        //                                      }
        //                                        ).ToList();
        //    ViewBag.vlt = valueTv;
        //    ViewBag.vlu = valueUser;
        //    if (ModelState.IsValid)
        //    {
        //        var s = db.News.Where(x => x.NewID == id).SingleOrDefault();
        //        if (İçerik != null)
        //        {

        //            if (System.IO.File.Exists(Server.MapPath(s.NewPath)))
        //            {
        //                System.IO.File.Delete(Server.MapPath(s.NewPath));
        //            }
        //            WebImage img = new WebImage(İçerik.InputStream);
        //            FileInfo imginfo = new FileInfo(İçerik.FileName);

        //            string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
        //            img.Resize(1024, 360);
        //            img.Save("~/Uploads/Slider/" + sliderimgname);

        //            s.NewPath = "/Uploads/Slider/" + sliderimgname;
        //        }
        //        s.NewID = news.NewID;
        //        s.NewName = news.NewName;
        //        s.NewCreationDate = news.NewCreationDate;
        //        s.NewPath = news.NewPath;
        //        s.NewStatus = news.NewStatus;
        //        s.NewDescription = news.NewDescription;
        //        s.TvID = news.TvID;
        //        s.UserID = news.UserID;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(news);
        //}
        public ActionResult DeleteNew(int id)
        {
            var newValues = Nm.GetByID(id);
            newValues.NewStatus = false;
            Nm.NewDelete(newValues);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}