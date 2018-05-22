using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace UmbracoDemo1.Demo.Demo20.Plugin
{
    public class ContactModelPlugin
    {
        [Required]
        [StringLength(100)]
        [Display(Description = "Complete name")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Only alphabet and numbers")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Description = "Email address")]
        public string Email { get; set; }

        [Required]
        [Display(Description = "Contact message")]
        public string Message { get; set; }

    }
}