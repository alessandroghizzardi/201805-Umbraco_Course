using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace UmbracoDemo1.Demo.Demo20
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            ContactModel m = new ContactModel();
            return PartialView("Demo20/ContactForm", m);
        }

        [HttpPost]
        public ActionResult HandlePost(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            MailMessage message = new MailMessage();
            message.From = new MailAddress(model.Email, model.Name);
            message.Subject = "Contact request from demo site";
            message.To.Add(new MailAddress("alessandro.ghizzardi@gmail.com", "Alessandro Ghizzardi"));
            message.Body = model.Message;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(message);

            TempData["Feedback"] = "Thank you for submitting";
            return RedirectToCurrentUmbracoPage();
        }
    }
}