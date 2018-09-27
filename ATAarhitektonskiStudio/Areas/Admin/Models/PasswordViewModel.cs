using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.Areas.Admin.Models
{
    public class PasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        [Required]
        public string RepeatNewPassword { get; set; }
    }
}