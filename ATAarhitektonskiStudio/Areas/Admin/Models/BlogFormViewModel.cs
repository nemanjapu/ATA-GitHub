using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Areas.Admin.Models
{
    public class BlogFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        [AllowHtml]
        public string Text { get; set; }
        public DateTime DatePublished { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string imageName { get; set; }
        public bool Active { get; set; }
    }
}