﻿using ATAarhitektonskiStudio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    [Authorization(isAdmin: true)]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}