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
        [Route("Venues")]
        public ActionResult Index()
        {
            TempData["TestFromIndex"] = "Test from index 2";
            ViewBag.TestFromIndex = "Test from index";
            return RedirectToAction("Detail", new { id = 10,  name = "prova" });
            //return View(); 
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