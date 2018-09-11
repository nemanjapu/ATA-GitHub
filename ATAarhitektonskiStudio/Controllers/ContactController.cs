using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = ctx.Global.Select(g => new ContactViewModel()
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
                YoutubeLink = g.YoutubeLink
            }).FirstOrDefault();

            return View(model);
        }
    }
}