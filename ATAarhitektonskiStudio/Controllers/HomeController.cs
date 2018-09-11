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
                hpProjects = ctx.Project.Include(pimg => pimg.Images).Where(p => p.isActive == true).OrderByDescending(p => p.DatePublished).Take(5)
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    PreviewImage = p.Images.FirstOrDefault(),
                    isActive = p.isActive,
                    Name = p.Name,
                    NameEng = p.NameEng
                }).ToList()
            };

            return View(model);
        }
    }
}