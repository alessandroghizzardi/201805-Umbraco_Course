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
            return View(); 
        }

        [Route("Venue/ViewDetail/{id:int}/{name}")]
        public ActionResult Detail(int id, string name)
        {
            ViewBag.VenueId = id;
            ViewBag.VenueName = name;

            ViewData["venueId"] = id;
            ViewData["venueName"] = name;
            
            TempData["venueId"] = id;
            TempData["venueName"] = name;

            return View();
        }


        [Route("Venue/ViewDetail/DirectBooking/{id:int}/{name}", Name = "DirectBookingRoute")]
        public ActionResult DirectBooking(int id, string name)
        {
            TempData["venueId"] = id;
            TempData["venueName"] = name;

            return RedirectToAction("Book");
        }



        [Route("Venue/Book")]
        public ActionResult Book()
        {
            int id = (int)TempData["venueId"];
            string name = (string)TempData["venueName"];

            ViewBag.VenueId = id;
            ViewBag.VenueName = name;

            ViewData["venueId"] = id;
            ViewData["venueName"] = name;

            return View();
        }
    }
}