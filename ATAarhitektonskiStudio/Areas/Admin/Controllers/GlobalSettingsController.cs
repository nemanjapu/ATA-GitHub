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
                YoutubeLink = gs.YoutubeLink
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