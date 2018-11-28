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
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = ctx.Global.AsNoTracking().Select(g => new ContactViewModel()
            {
                CellPhone = g.CellPhone,
                Email = g.Email,
                FacebookLink = g.FacebookLink,
                Fax = g.Fax,
                GooglePlusLink = g.GooglePlusLink,
                InstagramLink = g.InstagramLink,
                LinkedinLink = g.LinkedinLink,
                Location = g.Location,
                OfficePhone = g.OfficePhone,
                PinterestLink = g.PinterestLink,
                TwitterLink = g.TwitterLink,
                YoutubeLink = g.YoutubeLink,
                ContactMetaDescription = ctx.MetaTags.FirstOrDefault().ContactMetaDescription,
                ContactMetaKeywords = ctx.MetaTags.FirstOrDefault().ContactMetaKeywords
            }).FirstOrDefault();

            return View(model);
        }
    }
}