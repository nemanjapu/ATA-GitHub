using ATAarhitektonskiStudio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    [Authorization(isAdmin: true)]
    public class ProjectsManagerController : BaseAdminController
    {
        // GET: Admin/Projects
        public ActionResult Index()
        {
            var model = ctx.Project.ToList();

            return View(model);
        }
    }
}