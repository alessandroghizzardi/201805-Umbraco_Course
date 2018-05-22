using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace UmbracoDemo1.Libraries
{
    public class PublishEventHandlere : ApplicationEventHandler
    {

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            Umbraco.Core.Services.ContentService.Saved += ContentService_Saved;
            base.ApplicationStarted(umbracoApplication, applicationContext);
        }

        private void ContentService_Saved(Umbraco.Core.Services.IContentService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
        {
            string en = "1057";
            string it = "1058";

            foreach (var entity in e.SavedEntities)
            {
                string[] path = entity.Path.Split(',');

                if (path.Contains(en))
                {
                    //Starting cloning, getting 

                    var content = ApplicationContext.Current.Services.ContentService.CreateContent(
                        entity.Name, Convert.ToInt32(it), entity.ContentType.Alias);

                    content.SetValue("originalPath", entity.Path);
                    content.SetValue("body", entity.GetValue("body"));

                    //Services.ContentService.Save(content);
                    ApplicationContext.Current.Services.ContentService.Save(content);

                    //Send email
                }
            }
        }
    }
}