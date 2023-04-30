using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BelasitsaSkyRun.Umbraco.Models
{
    public class LoginModel
    {
        [Display(Name = "UserName")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required]     
        public string Email { get; set; }

        [Display(Name = "BirthPlace")]
        [Required]      
        public string BirthPlace { get; set; }

        [Display(Name = "BirthDate")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public bool Gender { get; set; }
    }
}
