﻿using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.SessionState;

namespace ATAarhitektonskiStudio.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ProjectsController : BaseController
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project(int id)
        {
            var model = ctx.Project.AsNoTracking().Where(p => p.Id == id).Select(p => new ProjectViewModel {
                Id = p.Id,
                Name = p.Name,
                Images = ctx.ProjectImages.Where(pimg => pimg.ProjectId == p.Id).AsEnumerable(),
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
                YoutubeVideoLink = p.YoutubeVideoLink,
                Level = p.Level,
                LevelEng = p.LevelEng,
                MetaDescription = p.MetaDescription,
                MetaKeywords = p.MetaKeywords
            }).FirstOrDefault();

            return View(model);
        }
    }
}