using ATAarhitektonskiStudio.Helpers;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string GetScript(this UrlHelper helper, string scriptFileName, bool localizable = true)
        {
            string strUrlPath, strFilePath = string.Empty;
            if (localizable)
            {
                /* Search result in current culture folder */
                strUrlPath = string.Format("/Content/Scripts/{0}/{1}", GlobalHelper.CurrentCulture, scriptFileName);
                strFilePath = HttpContext.Current.Server.MapPath(strUrlPath);
                if (!File.Exists(strFilePath))
                {   /* Search result in default culture folder */
                    strUrlPath = string.Format("/Content/{0}/Scripts/{1}", GlobalHelper.DefaultCulture, scriptFileName);
                }
                return strUrlPath;
            }

            strUrlPath = string.Format("/Content/Scripts/{0}", scriptFileName);
            strFilePath = HttpContext.Current.Server.MapPath(strUrlPath);
            if (File.Exists(strFilePath))
            {   /* search result in root directory folder */
                return strUrlPath;
            }

            return strUrlPath;
        }
    }
}