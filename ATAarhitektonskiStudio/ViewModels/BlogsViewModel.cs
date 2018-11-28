using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.ViewModels
{
    public class BlogsViewModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string CaptionEng { get; set; }
        public string Text { get; set; }
        public string TextEng { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public DateTime DatePublished { get; set; }
    }
}