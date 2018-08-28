using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Helpers
{
    public class Authorization : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool _IsAdmin;


        public Authorization(bool isAdmin = false)
        {
            _IsAdmin = isAdmin;
        }

        public void OnAuthorization(AuthorizationContext filter)
        {
            User loggedInUser = Authentication.GetLoggedInUser();
            bool accessGranted = false;

            if (loggedInUser != null)
            {
                if ((loggedInUser.isAdmin == true) && (_IsAdmin))
                    accessGranted = true;
            }

            if (!accessGranted)
            {
                filter.HttpContext.Response.Redirect("/");
            }
        }
    }
}