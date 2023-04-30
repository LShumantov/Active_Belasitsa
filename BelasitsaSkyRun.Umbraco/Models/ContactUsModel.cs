using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BelasitsaSkyRun.Umbraco.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { set; get; }  
            
        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Please write your message")]
        public string Message { get; set; }

    }
}