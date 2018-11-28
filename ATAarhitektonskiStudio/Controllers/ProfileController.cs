using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ATAarhitektonskiStudio.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            var model = ctx.Global.AsNoTracking().Select(x => new ProfileViewModel
            {
                AboutWriteUp = x.About,
                AboutWriteUpEng = x.AboutEng,
                ProfileMetaDescription = ctx.MetaTags.FirstOrDefault().ProfileMetaDescription,
                ProfileMetaKeywords = ctx.MetaTags.FirstOrDefault().ProfileMetaKeywords
            }).FirstOrDefault();
            return View(model);
        }
    }
}