using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ATAarhitektonskiStudio.DAL;
using ATAarhitektonskiStudio.Models;
using ATAarhitektonskiStudio.ViewModels;

namespace ATAarhitektonskiStudio.Controllers.API
{
    public class ProjectsApiController : ApiController
    {
        private databaseContext ctx = new databaseContext();

        // GET: api/ProjectsApi
        public IEnumerable<ProjectListMenuViewModel> GetProject()
        {
            IEnumerable<ProjectListMenuViewModel> model = ctx.Project.Where(p => p.isActive == true).AsEnumerable()
                .Select(p => new ProjectListMenuViewModel
                {
                    Name = p.Name,
                    Id = p.Id,
                    NameEng = p.NameEng
                });

            return model;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}