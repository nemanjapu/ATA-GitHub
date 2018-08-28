using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATAarhitektonskiStudio.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        [AllowHtml]
        public string Text { get; set; }
        public DateTime DatePublished { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool isActive { get; set; }
    }
}