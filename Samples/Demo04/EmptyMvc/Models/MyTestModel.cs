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
        [StringLength(100)]
        [Display(Description = "First Name")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Only alphabet and numbers")]
        public string FirstName { get; set; }


        public int ID { get; set; }

    }
}