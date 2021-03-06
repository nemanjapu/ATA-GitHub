﻿using System;
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
        public string Caption { get; set; }
        public string CaptionEng { get; set; }
        public string Text { get; set; }
        public string TextEng { get; set; }
        public DateTime DatePublished { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool isActive { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
}