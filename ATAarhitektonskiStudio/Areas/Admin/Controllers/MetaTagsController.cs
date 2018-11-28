using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    public class MetaTagsController : BaseAdminController
    {
        // GET: Admin/MetaTags
        public ActionResult Index()
        {
            var model = ctx.MetaTags.FirstOrDefault();

            return View(model);
        }

        public ActionResult SaveMetaTags(MetaTags model)
        {
            var metaDB = ctx.MetaTags.FirstOrDefault();

            metaDB.ContactMetaDescription = model.ContactMetaDescription;
            metaDB.ContactMetaKeywords = model.ContactMetaKeywords;
            metaDB.HomeMetaDescription = model.HomeMetaDescription;
            metaDB.HomeMetaKeywords = model.HomeMetaKeywords;
            metaDB.ProfileMetaDescription = model.ProfileMetaDescription;
            metaDB.ProfileMetaKeywords = model.ProfileMetaKeywords;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}