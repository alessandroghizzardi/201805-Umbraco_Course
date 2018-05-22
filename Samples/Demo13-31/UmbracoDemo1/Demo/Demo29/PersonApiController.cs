using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace UmbracoDemo1.Demo.Demo29
{
    [PluginController("Demo29CustomSection")]
    public class PersonApiController : UmbracoAuthorizedJsonController
    {
        PersonPOCO[] persons = new PersonPOCO[] {
            new PersonPOCO { Id = 1, FirstName = "Alessandro", LastName = "Ghizzardi" },
            new PersonPOCO { Id = 2, FirstName = "Mario", LastName = "Rossi" },
            new PersonPOCO { Id = 3, FirstName = "Luca", LastName = "Bianchi" },
            new PersonPOCO { Id = 4, FirstName = "Eleonora", LastName = "Sanfelice" },
            new PersonPOCO { Id = 5, FirstName = "Rosanna", LastName = "Casiraghi" }
        };

        public IEnumerable<PersonPOCO> GetAll()
        {
            return persons;
        }

        public PersonPOCO GetById(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);

        }

        public PersonPOCO PostSave(PersonPOCO person)
        {
            //Do nothing
            return person;
        }

        public int DeleteById(int id)
        {
            return 0;
        }

    }
}