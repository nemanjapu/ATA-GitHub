using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Models
{
    public class GlobalSettingsViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string OfficePhone { get; set; }
        public string Fax { get; set; }
        public string Location { get; set; }
        [AllowHtml]
        public string About { get; set; }
        [AllowHtml]
        public string AboutEng { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string PinterestLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string LinkedinLink { get; set; }
        public string YoutubeLink { get; set; }
        [AllowHtml]
        public string Heading1Homepage { get; set; }
        [AllowHtml]
        public string Heading1HomepageEng { get; set; }
        [AllowHtml]
        public string Heading2Homepage { get; set; }
        [AllowHtml]
        public string Heading2HomepageEng { get; set; }
        [AllowHtml]
        public string WritingHomepage { get; set; }
        [AllowHtml]
        public string WritingHomepageEng { get; set; }
        public bool ShowBlogsOnHomepage { get; set; }
    }
}