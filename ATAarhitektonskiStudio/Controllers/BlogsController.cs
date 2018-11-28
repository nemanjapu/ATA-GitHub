using ATAarhitektonskiStudio.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Controllers
{
    public class BlogsController : BaseController
    {
        // GET: Blogs
        public ActionResult Index(int? page)
        {
            var model = ctx.Blog.AsNoTracking().Where(b => b.isActive).OrderByDescending(b => b.DatePublished).Select(b => new BlogsViewModel
            {
                Caption = b.Caption,
                CaptionEng = b.CaptionEng,
                Text = b.Text,
                ImageName = b.ImageName,
                ImagePath = b.ImagePath,
                TextEng = b.TextEng,
                Id = b.Id,
                DatePublished = b.DatePublished
            });

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}