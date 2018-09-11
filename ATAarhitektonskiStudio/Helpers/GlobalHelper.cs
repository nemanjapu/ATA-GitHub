using ATAarhitektonskiStudio.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace ATAarhitektonskiStudio.Helpers
{
    public class GlobalHelper
    {
        public static string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }

        public static string DefaultCulture
        {
            get
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
                GlobalizationSection section = (GlobalizationSection)config.GetSection("system.web/globalization");
                return section.UICulture;
            }
        }

        public static string GetFacebook()
        {
            string ATAEmail;
			using (databaseContext db = new databaseContext { })
			{
				ATAEmail = db.Global.FirstOrDefault().FacebookLink;
			}
			return ATAEmail;
        }

        public static string GetInstagram()
        {
            string ATAInstagram;
            using (databaseContext db = new databaseContext { })
            {
                ATAInstagram = db.Global.FirstOrDefault().InstagramLink;
            }
            return ATAInstagram;
        }

        public static string GetTwitter()
        {
            string ATATwitter;
            using (databaseContext db = new databaseContext { })
            {
                ATATwitter = db.Global.FirstOrDefault().TwitterLink;
            }
            return ATATwitter;
        }

        public static string GetPinterest()
        {
            string ATAPinterest;
            using (databaseContext db = new databaseContext { })
            {
                ATAPinterest = db.Global.FirstOrDefault().PinterestLink;
            }
            return ATAPinterest;
        }

        public static string GetGooglePlus()
        {
            string ATAGooglePlus;
            using (databaseContext db = new databaseContext { })
            {
                ATAGooglePlus = db.Global.FirstOrDefault().GooglePlusLink;
            }
            return ATAGooglePlus;
        }

        public static string GetLinkedin()
        {
            string ATALinkedin;
            using (databaseContext db = new databaseContext { })
            {
                ATALinkedin = db.Global.FirstOrDefault().LinkedinLink;
            }
            return ATALinkedin;
        }

        public static string GetYoutube()
        {
            string ATAYoutube;
            using (databaseContext db = new databaseContext { })
            {
                ATAYoutube = db.Global.FirstOrDefault().YoutubeLink;
            }
            return ATAYoutube;
        }
    }
}