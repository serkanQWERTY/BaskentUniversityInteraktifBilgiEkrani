using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class NewGalleryController : Controller
    {
        // GET: NewGallery
        NewManager Nm = new NewManager(new EfNewDAL());
        [Authorize]
        public ActionResult Index()
        {
            var galleryitems = Nm.GetList();
            return View(galleryitems);
        }
    }
}