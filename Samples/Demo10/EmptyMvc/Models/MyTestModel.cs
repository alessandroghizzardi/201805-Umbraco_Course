using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmptyMvc.Models
{
    public class MyTestModel
    {
        [Required]
        [Display(Description = "ID")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Only numbers")]
        public int ID { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Description = "First Name")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Only alphabet and numbers")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Description = "Last Name")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Only alphabet and numbers")]
        public string LastName { get; set; }
        
    }
}