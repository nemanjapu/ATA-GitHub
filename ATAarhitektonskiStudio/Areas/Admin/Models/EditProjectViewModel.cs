using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Models
{
    public class EditProjectViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameEng { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string LocationEng { get; set; }
        [Required]
        public string SquareMeters { get; set; }
        [Required]
        public string SquareMetersEng { get; set; }
        [Required]
        public string YearBuilt { get; set; }
        [Required]
        public string YearBuiltEng { get; set; }
        [Required]
        public string Investor { get; set; }
        [Required]
        public string InvestorEng { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string TypeEng { get; set; }
        [Required]
        [AllowHtml]
        public string Text { get; set; }
        [Required]
        [AllowHtml]
        public string TextEng { get; set; }
        public virtual ICollection<ProjectImages> Images { get; set; }
        public IEnumerable<ProjectImages> EditImagesList { get; set; }
        public bool isActive { get; set; }
        public string YoutubeVideoLink { get; set; }
        public string Level { get; set; }
        public string LevelEng { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
}