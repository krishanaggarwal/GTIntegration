using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NaGreen.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string UserName { get; set; }
    }
}