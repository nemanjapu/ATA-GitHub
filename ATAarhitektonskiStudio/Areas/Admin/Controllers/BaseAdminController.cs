using ATAarhitektonskiStudio.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected databaseContext ctx = new databaseContext();

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}