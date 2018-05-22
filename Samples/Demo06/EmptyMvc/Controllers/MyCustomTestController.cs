using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmptyMvc.Controllers
{
    [RoutePrefix("Restaurants")]
    public class MyCustomTestController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }

        [Route("Venue/ViewDetail/{id:int}/{name}")]
        public ActionResult Detail(string id, string name)
        {
            ViewBag.VenueId = id;
            ViewBag.VenueName = name;

            return View();
        }
    }
}