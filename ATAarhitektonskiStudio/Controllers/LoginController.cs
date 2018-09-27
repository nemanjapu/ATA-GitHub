using ATAarhitektonskiStudio.Helpers;
using ATAarhitektonskiStudio.Models;
using ATAarhitektonskiStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            User k = Authentication.GetLoggedInUser();
            if (k != null)
            {
                if (k.isAdmin == true)
                {
                    return RedirectToAction("Index", "ProjectsManager", new { area = "Admin" });
                }
            }
            LoginViewModel viewModel = new LoginViewModel();

            return View(viewModel);
        }
        public ActionResult Check(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                User userDB = ctx.User.SingleOrDefault(s => s.Email == user.Email.Trim());
                if (userDB != null)
                {
                    if ((Helpers.PasswordHashing.GenerateHash(user.Password, userDB.PasswordSalt) == userDB.PasswordHash))
                    {
                        if (userDB.isAdmin == true)
                        {
                            Authentication.StartSession(userDB, user.isRemember);
                            return RedirectToAction("Index", "ProjectsManager", new { area = "Admin" });
                        }
                    }
                    else
                    {
                        return View("Index", user);
                    }
                }
            }

            return View("Index", user);
        }

        public ActionResult Logout()
        {
            Authentication.ClearSession();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}