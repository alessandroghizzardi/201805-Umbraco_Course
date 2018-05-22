using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmptyMvc.Controllers
{
    public class MyTestController : Controller
    {
        // GET: MyTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Helpers()
        {
            return View();
        }

        public ActionResult RedirectToRoute()
        {
            return this.RedirectToRoutePermanent(new RouteValueDictionary(
               new { action = "Index", controller = "Home" }));
        }

        public ActionResult RedirectToAction()
        {
            return this.RedirectToAction("Index", "Home", new RouteValueDictionary());
        }
    }
}