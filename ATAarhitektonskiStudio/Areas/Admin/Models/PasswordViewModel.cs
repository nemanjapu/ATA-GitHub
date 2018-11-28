using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.Areas.Admin.Models
{
    public class PasswordViewModel
    {
        [Required(ErrorMessage = "Stara lozinka je obavezno polje.")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Nova lozinka je obavezno polje.")]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "Lozinke se ne poklapaju.")]
        [Required(ErrorMessage = "Molimo ponovite novu lozinku.")]
        public string RepeatNewPassword { get; set; }
    }
}