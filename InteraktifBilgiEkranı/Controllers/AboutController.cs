using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}