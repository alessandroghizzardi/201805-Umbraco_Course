using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;

namespace UmbracoDemo1.Demo.Demo19
{
    public class HomepageController : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            ViewBag.TestFromCustomController = "This is a test from custom controller";
            
            DemoCustomModel customModel = new DemoCustomModel(model.Content);
            customModel.MyCustomProperty = string.Format("Custom property generated at {0}",
                DateTime.Now.ToString());

            return base.Index(customModel);
        }

    }
}