using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class UserGalleryController : Controller
    {
        UserManager Um = new UserManager(new EfUserDAL());
        NewManager Nm = new NewManager(new EfNewDAL());
        // GET: UserGallery
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var usergalleryinfos = Um.GetList();
            return View(usergalleryinfos);
        }

        [HttpGet]
        [Authorize]
        public ActionResult NewByUser(int id)
        {
            var newValues = Nm.GetListByUserID(id);
            return View(newValues);
        }
    }
}