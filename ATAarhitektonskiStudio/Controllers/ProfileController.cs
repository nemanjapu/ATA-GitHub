using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            var model = ctx.Global.Select(x => new ProfileViewModel
            {
                AboutWriteUp = x.About,
                AboutWriteUpEng = x.AboutEng
            }).FirstOrDefault();
            return View(model);
        }
    }
}