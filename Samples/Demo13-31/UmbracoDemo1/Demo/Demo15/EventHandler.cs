using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web.Routing;

namespace UmbracoDemo1.Demo.Demo15
{
    public class EventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarting(umbracoApplication, applicationContext);

            ContentLastChanceFinderResolver.Current.SetFinder(new Demo404ContentFinder());

            ContentFinderResolver.Current
                .InsertTypeBefore<ContentFinderByNiceUrl, DemoHandleWootContentFinder>();
        }
    }
}