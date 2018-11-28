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

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers.ApiControllers
{
    public class ProjectImagesController : ApiController
    {
        private databaseContext db = new databaseContext();

        // GET: api/ProjectImages
        public IQueryable<ProjectImages> GetProjectImages()
        {
            return db.ProjectImages;
        }



        [HttpPost]
        public IHttpActionResult SetImagesOrder(IEnumerable<ProjectImages> images)
        {
            foreach (var img in images)
            {
                var DbImage = db.ProjectImages.Where(li => li.Id == img.Id).FirstOrDefault();
                DbImage.SortOrder = img.SortOrder;

            }

            db.SaveChanges();

            return Ok();
        }



        // GET: api/ProjectImages/5
        [ResponseType(typeof(ProjectImages))]
        public IHttpActionResult GetProjectImages(int id)
        {
            ProjectImages projectImages = db.ProjectImages.Find(id);
            if (projectImages == null)
            {
                return NotFound();
            }

            return Ok(projectImages);
        }

        // PUT: api/ProjectImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjectImages(int id, ProjectImages projectImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectImages.Id)
            {
                return BadRequest();
            }

            db.Entry(projectImages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectImagesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProjectImages
        [ResponseType(typeof(ProjectImages))]
        public IHttpActionResult PostProjectImages(ProjectImages projectImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectImages.Add(projectImages);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectImages.Id }, projectImages);
        }

        // DELETE: api/ProjectImages/5
        [ResponseType(typeof(ProjectImages))]
        public IHttpActionResult DeleteProjectImages(int id)
        {
            ProjectImages projectImages = db.ProjectImages.Find(id);
            if (projectImages == null)
            {
                return NotFound();
            }

            db.ProjectImages.Remove(projectImages);
            db.SaveChanges();

            return Ok(projectImages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectImagesExists(int id)
        {
            return db.ProjectImages.Count(e => e.Id == id) > 0;
        }
    }
}