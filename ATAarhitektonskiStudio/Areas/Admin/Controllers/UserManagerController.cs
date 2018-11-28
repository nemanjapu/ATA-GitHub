using ATAarhitektonskiStudio.Areas.Admin.Models;
using ATAarhitektonskiStudio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Controllers
{
    [Authorization(isAdmin: true)]
    public class UserManagerController : BaseAdminController
    {
        // GET: Admin/UserManager
        public ActionResult Index()
        {
            var model = new PasswordViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveNewPassword(PasswordViewModel model)
        {
            var userId = Helpers.Authentication.GetUserID();

            var user = ctx.User.Find(userId);

            if (PasswordHashing.GenerateHash(model.OldPassword, user.PasswordSalt) == user.PasswordHash)
            {
                string newHash = PasswordHashing.GenerateHash(model.NewPassword, user.PasswordSalt);
                user.PasswordHash = newHash;
                ctx.SaveChanges();

                return RedirectToAction("Index", "ProjectsManager");
            }

            ModelState.AddModelError(String.Empty, "Neispravna stara lozinka. Molimo pokušajte ponovo.");

            return View("Index", model);
        }
    }
}