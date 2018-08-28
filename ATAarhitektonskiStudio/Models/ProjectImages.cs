using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.Models
{
    public class ProjectImages
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int SortOrder { get; set; }
        public string FileNameNoExt { get; set; }
        public string FilePath { get; set; }
    }
}