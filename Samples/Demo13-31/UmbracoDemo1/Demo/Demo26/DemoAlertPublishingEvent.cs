using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;

namespace UmbracoDemo1.Demo.Demo26
{
    public class DemoAlertPublishingEvent : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            Umbraco.Core.Services.ContentService.Publishing += ContentService_Publishing;
            base.ApplicationStarted(umbracoApplication, applicationContext);
        }

        private void ContentService_Publishing(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            foreach (var entity in e.PublishedEntities)
            {
                if (entity.ContentType.Alias == "homepage")
                {
                    //Prevent thomepage from being published and send email
                    e.Cancel = true;

                    var user = ApplicationContext.Current.Services.UserService.GetByProviderKey(entity.WriterId);

                   var body = string.Format("On {0} the user {1} reuqest for publishing homepage node",
                        DateTime.Now, user.Name);

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("noreply@umbraco.com");
                    message.Subject = "Request for homepage publishing";
                    message.To.Add(new MailAddress("alessandro.ghizzardi@gmail.com", "Alessandro Ghizzardi"));
                    message.Body = body;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(message);

                    LogHelper.Info(typeof(DemoAlertPublishingEvent), "Publishing handled by custom code");
                }

            }
        }
    }
}