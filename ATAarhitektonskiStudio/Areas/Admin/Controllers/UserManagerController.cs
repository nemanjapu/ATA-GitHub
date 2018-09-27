using ATAarhitektonskiStudio.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    public class UserManagerController : BaseAdminController
    {
        // GET: Admin/UserManager
        public ActionResult Index()
        {
            var userId = Helpers.Authentication.GetUserID();
            var model = new PasswordViewModel();

            return View(model);
        }

        public ActionResult SaveNewPassword()
        {
            var userId = Helpers.Authentication.GetUserID();
            var model = ctx.User.Where(u => u.Id == userId).Select(u => new PasswordViewModel
            {

            }).FirstOrDefault();

            return View();
        }
    }
}