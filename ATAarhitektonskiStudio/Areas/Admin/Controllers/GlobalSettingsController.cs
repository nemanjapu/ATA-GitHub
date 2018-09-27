using ATAarhitektonskiStudio.Areas.Admin.Models;
using ATAarhitektonskiStudio.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    [Authorization(isAdmin: true)]
    public class GlobalSettingsController : BaseAdminController
    {
        // GET: Admin/GlobalSettings
        public ActionResult Index()
        {
            var gs = ctx.Global.FirstOrDefault();

            var model = new GlobalSettingsViewModel
            {
                About = gs.About,
                AboutEng = gs.AboutEng,
                CellPhone = gs.CellPhone,
                Email = gs.Email,
                FacebookLink = gs.FacebookLink,
                Fax = gs.Fax,
                GooglePlusLink = gs.GooglePlusLink,
                Id = gs.Id,
                InstagramLink = gs.InstagramLink,
                LinkedinLink = gs.LinkedinLink,
                Location = gs.Location,
                OfficePhone = gs.OfficePhone,
                PinterestLink = gs.PinterestLink,
                TwitterLink = gs.TwitterLink,
                YoutubeLink = gs.YoutubeLink,
                Heading1Homepage = gs.Heading1Homepage,
                Heading1HomepageEng = gs.Heading1HomepageEng,
                Heading2Homepage = gs.Heading2Homepage,
                Heading2HomepageEng = gs.Heading2HomepageEng,
                WritingHomepage = gs.WritingHomepage,
                WritingHomepageEng = gs.WritingHomepageEng
            };

            return View(model);
        }

        public ActionResult SaveSettings(GlobalSettingsViewModel gs)
        {
            var gsDB = ctx.Global.FirstOrDefault();

            gsDB.About = gs.About;
            gsDB.AboutEng = gs.AboutEng;
            gsDB.CellPhone = gs.CellPhone;
            gsDB.Email = gs.Email;
            gsDB.FacebookLink = gs.FacebookLink;
            gsDB.Fax = gs.Fax;
            gsDB.GooglePlusLink = gs.GooglePlusLink;
            gsDB.InstagramLink = gs.InstagramLink;
            gsDB.LinkedinLink = gs.LinkedinLink;
            gsDB.Location = gs.Location;
            gsDB.OfficePhone = gs.OfficePhone;
            gsDB.PinterestLink = gs.PinterestLink;
            gsDB.TwitterLink = gs.TwitterLink;
            gsDB.YoutubeLink = gs.YoutubeLink;
            gsDB.Heading1Homepage = gs.Heading1Homepage;
            gsDB.Heading1HomepageEng = gs.Heading1HomepageEng;
            gsDB.Heading2Homepage = gs.Heading2Homepage;
            gsDB.Heading2HomepageEng = gs.Heading2HomepageEng;
            gsDB.WritingHomepage = gs.WritingHomepage;
            gsDB.WritingHomepageEng = gs.WritingHomepageEng;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public string UploadImage(HttpPostedFileBase file)
        {
            var path = "~/DynamicContent/AboutImages";
            var imgPath = "";

            if (file != null)
            {
                imgPath = Path.Combine(Server.MapPath(path), file.FileName);
                file.SaveAs(imgPath);
            }

            return @"/DynamicContent/AboutImages/" + file.FileName;
        }
    }
}