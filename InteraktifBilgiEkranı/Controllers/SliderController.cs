﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InteraktifBilgiEkranı.Controllers
{
    public class SliderController : Controller
    {
        NewManager Nm = new NewManager(new EfNewDAL());
        // GET: Slider
        public ActionResult Index()
        {
            var newValues = Nm.GetList();
            return View(newValues);
        }
    }
}