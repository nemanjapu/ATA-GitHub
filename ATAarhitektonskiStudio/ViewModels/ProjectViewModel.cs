﻿using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Location { get; set; }
        public string LocationEng { get; set; }
        public string SquareMeters { get; set; }
        public string SquareMetersEng { get; set; }
        public string YearBuilt { get; set; }
        public string YearBuiltEng { get; set; }
        public string Investor { get; set; }
        public string InvestorEng { get; set; }
        public string Type { get; set; }
        public string TypeEng { get; set; }
        public string Text { get; set; }
        public string TextEng { get; set; }
        public virtual List<ProjectImages> Images { get; set; }
        public bool isActive { get; set; }
        public ProjectImages PreviewImage { get; set; }
        public string YoutubeVideoLink { get; set; }
    }
}