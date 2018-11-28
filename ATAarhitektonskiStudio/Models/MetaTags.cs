using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.Models
{
    public class MetaTags
    {
        public int Id { get; set; }
        public string HomeMetaKeywords { get; set; }
        public string HomeMetaDescription { get; set; }
        public string ContactMetaKeywords { get; set; }
        public string ContactMetaDescription { get; set; }
        public string ProfileMetaKeywords { get; set; }
        public string ProfileMetaDescription { get; set; }
    }
}