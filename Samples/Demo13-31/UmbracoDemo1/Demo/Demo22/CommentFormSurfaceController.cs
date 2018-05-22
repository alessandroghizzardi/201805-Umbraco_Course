using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace UmbracoDemo1.Demo.Demo22
{
    public class CommentFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            CommentModel m = new CommentModel();
            return PartialView("Demo22/CommentForm", m);
        }

        [HttpPost]
        public ActionResult HandlePost(CommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            string nodeName = string.Format("{0}-Comment", DateTime.Now.ToString("yyyy-MM-dd"));
            var content = Services.ContentService.CreateContent(nodeName, CurrentPage.Id, "comment");

            content.SetValue("fullName", model.Name);
            content.SetValue("email", model.Email);
            content.SetValue("message", model.Message);
            content.SetValue("date", DateTime.Now);

            //Services.ContentService.Save(content);
            Services.ContentService.SaveAndPublishWithStatus(content);

            TempData["Feedback"] = "Thank you for commenting";
            return RedirectToCurrentUmbracoPage();
        }
    }
}