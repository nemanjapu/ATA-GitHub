using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ATAarhitektonskiStudio.Helpers
{
    public class RegexHelper
    {
        public static string RemoveDashesFromImagesNames(string imgName)
        {
            string newName = Regex.Replace(imgName, "_", " ");

            return newName;
        }
    }
}