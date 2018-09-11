using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ATAarhitektonskiStudio.Controllers
{
    public class ProjectsController : BaseController
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProjectsListMenu()
        {
            var model = ctx.Project.Select(pm => new ProjectListMenuViewModel() {
                Id = pm.Id,
                Name = pm.Name,
                NameEng = pm.NameEng
            }).ToList();

            return PartialView(model);
        }

        public ActionResult Project(int id)
        {
            var model = ctx.Project.Where(p => p.Id == id).Select(p => new ProjectViewModel {
                Id = p.Id,
                Name = p.Name,
                Images = ctx.ProjectImages.Where(pimg => pimg.ProjectId == p.Id).ToList(),
                Investor = p.Investor,
                InvestorEng = p.InvestorEng,
                isActive = p.isActive,
                Location = p.Location,
                LocationEng = p.LocationEng,
                NameEng = p.NameEng,
                SquareMeters = p.SquareMeters,
                SquareMetersEng = p.SquareMetersEng,
                Text = p.Text,
                TextEng = p.TextEng,
                Type = p.Type,
                TypeEng = p.TypeEng,
                YearBuilt = p.YearBuilt,
                YearBuiltEng = p.YearBuiltEng,
                YoutubeVideoLink = p.YoutubeVideoLink
            }).FirstOrDefault();

            return View(model);
        }
    }
}