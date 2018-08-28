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
    public class BlogManagerController : BaseAdminController
    {
        // GET: Admin/BlogManager
        public ActionResult Index()
        {
            var model = ctx.Blog.ToList();

            return View(model);
        }

        [HttpPost]
        public string UploadImage(HttpPostedFileBase file)
        {
            var path = "~/DynamicContent/BlogImages";
            var imgPath = "";

            if (file != null)
            {
                imgPath = Path.Combine(Server.MapPath(path), file.FileName);
                file.SaveAs(imgPath);
            }

            return @"/DynamicContent/BlogImages/" + file.FileName;
        }

        public ActionResult NewBlog()
        {
            var viewModel = new BlogFormViewModel
            {
                Id = new int(),
                imageName = "/Content/Images/upload-icon.png"
            };

            return View("AddBlog", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BlogFormViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = new BlogFormViewModel
                {
                    Caption = blog.Caption,
                    Text = blog.Text,
                    Active = blog.Active,
                    imageName = "/Content/Images/upload-icon.png"
                };
                return View("AddBlog", errorModel);
            }

            if (blog.Id == 0)
            {
                if (blog.File != null && blog.File.ContentLength > 0)
                {
                    var path = "/DynamicContent/BlogImages";
                    var blogDB = new Blog
                    {
                        Caption = blog.Caption,
                        Text = blog.Text,
                        isActive = blog.Active,
                        DatePublished = DateTime.Now,
                        UserId = Helpers.Authentication.GetLoggedInUser().Id,
                        ImageName = blog.File.FileName,
                        ImagePath = Path.Combine(Server.MapPath(path), blog.File.FileName)
                    };
                    ctx.Blog.Add(blogDB);
                    blog.File.SaveAs(blogDB.ImagePath);
                }
                else
                {
                    var errorModel = new BlogFormViewModel
                    {
                        Caption = blog.Caption,
                        Text = blog.Text,
                        Active = blog.Active,
                        imageName = "/Content/Images/upload-icon.png"
                    };
                    ModelState.AddModelError("", "Glavna slika je obavezna, molimo odaberite sliku.");
                    return View("AddBlog", errorModel);
                }
            }
            else
            {
                var blogDB = ctx.Blog.Find(blog.Id);

                var path = "/DynamicContent/BlogImages";

                blogDB.Caption = blog.Caption;
                blogDB.Text = blog.Text;
                blogDB.isActive = blog.Active;
                if (blog.File != null)
                {
                    blogDB.ImageName = blog.File.FileName;
                    blogDB.ImagePath = Path.Combine(Server.MapPath(path), blog.File.FileName);
                    blog.File.SaveAs(blogDB.ImagePath);
                }
            }

            ctx.SaveChanges();

            return RedirectToAction("Index", "BlogManager", new { area = "Admin" });
        }

        public ActionResult EditBlog(int id)
        {
            var blog = ctx.Blog.Find(id);

            var model = new BlogFormViewModel
            {
                Caption = blog.Caption,
                Text = blog.Text,
                Active = blog.isActive,
                imageName = "/DynamicContent/BlogImages/" + blog.ImageName
            };

            return View("EditBlog", model);
        }

        public ActionResult InactiveBlogs()
        {
            var blogs = ctx.Blog.Where(b => b.isActive == false).ToList();

            return View(blogs);
        }

        public ActionResult ToggleActive(int id)
        {
            Blog blog = ctx.Blog.Find(id);

            if (blog.isActive == true)
            {
                blog.isActive = false;
            }
            else
            {
                blog.isActive = true;
            }

            ctx.SaveChanges();

            return RedirectToAction("Index", "BlogManager");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteBlog(int id)
        {
            var blog = ctx.Blog.Find(id);

            ctx.Blog.Remove(blog);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}