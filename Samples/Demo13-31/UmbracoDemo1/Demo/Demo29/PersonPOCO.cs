using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoDemo1.Demo.Demo29
{
    public class PersonPOCO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}