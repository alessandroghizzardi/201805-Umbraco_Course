using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyMvc.Models
{
    public class ApiResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public bool IsCorrect { get; set; }
        public string SomeOtherProperty { get; set; }
    }
}