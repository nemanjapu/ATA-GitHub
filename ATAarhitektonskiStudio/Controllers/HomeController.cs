using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ATAarhitektonskiStudio.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new HomepageViewModel
            {
                Heading1 = ctx.Global.AsNoTracking().FirstOrDefault().Heading1Homepage,
                Heading1Eng = ctx.Global.AsNoTracking().FirstOrDefault().Heading1HomepageEng,
                Heading2 = ctx.Global.AsNoTracking().FirstOrDefault().Heading2Homepage,
                Heading2Eng = ctx.Global.AsNoTracking().FirstOrDefault().Heading2HomepageEng,
                Text = ctx.Global.AsNoTracking().FirstOrDefault().WritingHomepage,
                TextEng = ctx.Global.AsNoTracking().FirstOrDefault().WritingHomepageEng
            };

            return View(model);
        }
    }
}