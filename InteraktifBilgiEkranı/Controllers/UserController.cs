using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class UserController : Controller
    {
        UserManager Um = new UserManager(new EfUserDAL());
        RoleManager Rm = new RoleManager(new EfRoleDAL());
        DepartmentManager Dm = new DepartmentManager(new EfDepartmentDAL());
        FacultyManager Fm = new FacultyManager(new EfFacultyDAL());
        private Context c = new Context();
        // GET: User
        [Authorize(Roles = "ADM,CAD,SEK,İDP")]
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
        public ActionResult AddUser(User p , string q)
        {
            string k = (string)Session["UserMail"];
            q = c.Users.Where(x => x.UserMail == k).Select(y => y.Role.RoleShortName).FirstOrDefault();

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageUser/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.UserPath = "/ImageUser/" + dosyaadi + uzanti;
            }
            p.UserCreationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UserPassword = Crypto.Hash(p.UserPassword, "MD5");
            switch (q)
            {
                case "ADM": p.Permission = 3;
                    break;
                case "CAD": p.Permission = 4;
                    break;
                case "SEK": p.Permission = 5;
                    break;
                case "İDP": p.Permission = 6;
                    break;
            }
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
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageUser/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.UserPath = "/ImageUser/" + dosyaadi + uzanti;
            }
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

        public ActionResult ReportUser()
        {
            ViewBag.title = "Kullanıcı Raporlama Sayfası";
            var userValues = Um.GetList();
            return View(userValues);
        }

        [HttpGet]
        public ActionResult UserProfile(int id = 0)
        {
            string p = (string)Session["UserMail"];
            id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var userValues = Um.GetByID(id);
            return View(userValues);
        }

        [HttpPost]
        public ActionResult UserProfile(User p)
        {
            Um.UserUpdate(p);
            return RedirectToAction("Index", "About");
        }
    }
}