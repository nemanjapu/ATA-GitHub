using ATAarhitektonskiStudio.DAL;
using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.Helpers
{
    public class Authentication
    {
        private const string _LoggedInUser = "LoggedInUser";
        private const string _Cookie = "Cookie";


        public static void StartSession(User user, bool rememberMe = false)
        {
            HttpContext.Current.Session.Add(_LoggedInUser, user.Id);

            if (rememberMe)
            {
                HttpCookie cookie = new HttpCookie(_Cookie, user.Id.ToString() ?? "");
                cookie.Expires = DateTime.Now.AddDays(1d);
                HttpContext.Current.Response.Cookies.Add(cookie: cookie);
            }
        }


        public static void ClearSession()
        {
            ClearSessionValues();
            ClearCookieValues();
        }


        private static void ClearSessionValues()
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session[_LoggedInUser] = null;
        }


        private static void ClearCookieValues()
        {
            HttpContext.Current.Response.Cookies[_Cookie].Value = null;
        }

        public static User GetLoggedInUser()
        {
            User currentUser = GetUserIfAny();

            if (currentUser != null)
                return currentUser;

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(_Cookie);

            if (cookie != null)
            {
                long userID = 0;
                bool found = long.TryParse(cookie.Value, out userID);

                if (found)
                {
                    User userToLogin = null;
                    try
                    {
                        using (databaseContext db = new databaseContext { })
                        {
                            userToLogin = db.User
                                .AsNoTracking()
                                .SingleOrDefault(e => e.Id == userID);
                            StartSession(user: userToLogin, rememberMe: true);
                        }
                        return userToLogin;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public static User GetUserIfAny()
        {
            if (HttpContext.Current.Session[_LoggedInUser] != null)
            {
                int userID = (int)HttpContext.Current.Session[_LoggedInUser];
                using (databaseContext db = new databaseContext { })
                {
                    return db.User.SingleOrDefault(u => u.Id == userID);
                }
            }
            return null;
        }

        public static int? GetUserID()
        {
            if (HttpContext.Current.Session[_LoggedInUser] != null)
            {
                User currentUser = GetUserIfAny();
                return currentUser.Id;
            }
            return null;
        }
    }
}