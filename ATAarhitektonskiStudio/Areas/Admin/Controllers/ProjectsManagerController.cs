using ATAarhitektonskiStudio.Areas.Admin.Models;
using ATAarhitektonskiStudio.Helpers;
using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    [Authorization(isAdmin: true)]
    public class ProjectsManagerController : BaseAdminController
    {
        // GET: Admin/Projects
        public ActionResult Index()
        {
            var model = ctx.Project.ToList();

            return View(model);
        }

        public ActionResult NewProject()
        {
            var model = new AddProjectViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNewProject(AddProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = new AddProjectViewModel()
                {
                    Investor = model.Investor,
                    InvestorEng = model.InvestorEng,
                    Location = model.Location,
                    LocationEng = model.LocationEng,
                    Name = model.Name,
                    isActive = model.isActive,
                    NameEng = model.NameEng,
                    SquareMeters = model.SquareMeters,
                    SquareMetersEng = model.SquareMetersEng,
                    Text = model.Text,
                    TextEng = model.TextEng,
                    Type = model.Type,
                    TypeEng = model.TypeEng,
                    YearBuilt = model.YearBuilt,
                    YearBuiltEng = model.YearBuiltEng,
                    YoutubeVideoLink = model.YoutubeVideoLink
                };

                return View("NewProject", errorModel);
            }
            else
            {
                List<ProjectImages> images = new List<ProjectImages>();
                string folderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                Directory.CreateDirectory(Server.MapPath("~/DynamicContent/ProjectImages/Project" + folderDate));
                var path = "~/DynamicContent/ProjectImages/Project" + folderDate;
                var pathToSave = "DynamicContent/ProjectImages/Project" + folderDate;
                var imgPath = "";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ProjectImages fileDetail = new ProjectImages()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileNameNoExt = Path.GetFileNameWithoutExtension(fileName),
                            FilePath = pathToSave
                        };
                        images.Add(fileDetail);

                        imgPath = Path.Combine(Server.MapPath(path), fileDetail.FileName);
                        file.SaveAs(imgPath);
                    }
                }

                var dbProject = new Project
                {
                    DatePublished = DateTime.Now,
                    YearBuiltEng = model.YearBuiltEng,
                    Images = images,
                    Investor = model.Investor,
                    InvestorEng = model.InvestorEng,
                    isActive = model.isActive,
                    Location = model.Location,
                    LocationEng = model.LocationEng,
                    Name = model.Name,
                    NameEng = model.NameEng,
                    SquareMeters = model.SquareMeters,
                    SquareMetersEng = model.SquareMetersEng,
                    Text = model.Text,
                    TextEng = model.TextEng,
                    Type = model.Type,
                    TypeEng = model.TypeEng,
                    YearBuilt = model.YearBuilt,
                    YoutubeVideoLink = model.YoutubeVideoLink
                };

                ctx.Project.Add(dbProject);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditProject(int id)
        {
            var model = ctx.Project.Where(p => p.Id == id).AsEnumerable().Select(p => new EditProjectViewModel
            {
                Id = p.Id,
                YearBuiltEng = p.YearBuiltEng,
                EditImagesList = ctx.ProjectImages.Where(pimg => pimg.ProjectId == id).OrderBy(limg => limg.SortOrder).ThenBy(i => i.Id).ToList(),
                Investor = p.Investor,
                InvestorEng = p.InvestorEng,
                isActive = p.isActive,
                Location = p.Location,
                LocationEng = p.LocationEng,
                Name = p.Name,
                NameEng = p.NameEng,
                SquareMeters = p.SquareMeters,
                SquareMetersEng = p.SquareMetersEng,
                Text = p.Text,
                TextEng = p.TextEng,
                Type = p.Type,
                TypeEng = p.TypeEng,
                YearBuilt = p.YearBuilt,
                YoutubeVideoLink = p.YoutubeVideoLink
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditedProject(EditProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = new EditProjectViewModel()
                {
                    Id = model.Id,
                    Investor = model.Investor,
                    InvestorEng = model.InvestorEng,
                    Location = model.Location,
                    LocationEng = model.LocationEng,
                    Name = model.Name,
                    isActive = model.isActive,
                    NameEng = model.NameEng,
                    SquareMeters = model.SquareMeters,
                    SquareMetersEng = model.SquareMetersEng,
                    Text = model.Text,
                    TextEng = model.TextEng,
                    Type = model.Type,
                    TypeEng = model.TypeEng,
                    YearBuilt = model.YearBuilt,
                    YearBuiltEng = model.YearBuiltEng,
                    YoutubeVideoLink = model.YoutubeVideoLink
                };

                return View("EditProject", errorModel);
            }
            else
            {
                var proDB = ctx.Project.Find(model.Id);

                List<ProjectImages> images = new List<ProjectImages>();
                var pathToSave = ctx.ProjectImages.Where(pimg => pimg.ProjectId == model.Id).FirstOrDefault().FilePath;
                var path = "~/" + pathToSave;
                var imgPath = "";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ProjectImages fileDetail = new ProjectImages()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            FileNameNoExt = Path.GetFileNameWithoutExtension(fileName),
                            FilePath = pathToSave
                        };
                        images.Add(fileDetail);

                        imgPath = Path.Combine(Server.MapPath(path), fileDetail.FileName);
                        file.SaveAs(imgPath);
                    }
                }
                var newImages = proDB.Images.Concat(images).ToList();
                proDB.Images = newImages;
                proDB.Investor = model.Investor;
                proDB.InvestorEng = model.InvestorEng;
                proDB.isActive = model.isActive;
                proDB.Location = model.Location;
                proDB.LocationEng = model.LocationEng;
                proDB.Name = model.Name;
                proDB.NameEng = model.NameEng;
                proDB.SquareMeters = model.SquareMeters;
                proDB.SquareMetersEng = model.SquareMetersEng;
                proDB.Text = model.Text;
                proDB.TextEng = model.TextEng;
                proDB.Type = model.Type;
                proDB.TypeEng = model.TypeEng;
                proDB.YearBuilt = model.YearBuilt;
                proDB.YearBuiltEng = model.YearBuiltEng;
                proDB.YoutubeVideoLink = model.YoutubeVideoLink;

                ctx.SaveChanges();
            }

            return RedirectToAction("EditProject", new { id = model.Id });
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteProject(int id)
        {
            string imagesFolder = ctx.ProjectImages.Where(b => b.ProjectId == id).FirstOrDefault().FilePath;
            ctx.ProjectImages.RemoveRange(ctx.ProjectImages.Where(b => b.ProjectId == id));

            var project = ctx.Project.Find(id);
            string mappedPath = Server.MapPath(@"~/" + imagesFolder);

            Directory.Delete(mappedPath, true);

            ctx.Project.Remove(project);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteImage(int id)
        {
            var image = ctx.ProjectImages.Find(id);
            int imagesCount = ctx.ProjectImages.Where(pimg => pimg.ProjectId == image.ProjectId).ToList().Count();
            if (imagesCount > 1)
            {
                string fullPath = Request.MapPath("~/" + image.FilePath + "/" + image.FileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                ctx.ProjectImages.Remove(image);
                ctx.SaveChanges();
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}