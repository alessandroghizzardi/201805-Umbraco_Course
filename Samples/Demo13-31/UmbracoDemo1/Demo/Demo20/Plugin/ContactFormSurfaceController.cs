using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace UmbracoDemo1.Demo.Demo20.Plugin
{
    [PluginController("Demo20ContactFormPlugin")]
    public class ContactFormPluginSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            ContactModelPlugin m = new ContactModelPlugin();
            return PartialView("ContactForm", m);
        }

        [HttpPost]
        public ActionResult HandlePluginPost(ContactModelPlugin model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            MailMessage message = new MailMessage();
            message.From = new MailAddress(model.Email, model.Name);
            message.Subject = "Contact request from demo site (from plugin)";
            message.To.Add(new MailAddress("alessandro.ghizzardi@gmail.com", "Alessandro Ghizzardi"));
            message.Body = model.Message;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(message);

            TempData["Feedback"] = "Thank you for submitting (from plugin)";
            return RedirectToCurrentUmbracoPage();
        }
    }
}