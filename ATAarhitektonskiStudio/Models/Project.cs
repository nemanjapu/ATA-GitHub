using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string SquareMeters { get; set; }
        public string YearBuilt { get; set; }
        public string Investor { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual ICollection<ProjectImages> Images { get; set; }
        public bool isActive { get; set; }
    }
}