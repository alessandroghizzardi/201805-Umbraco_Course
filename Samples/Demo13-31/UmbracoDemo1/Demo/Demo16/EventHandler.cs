using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Strings;
using Umbraco.Web.Routing;

namespace UmbracoDemo1.Demo.Demo16
{
    public class EventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarting(umbracoApplication, applicationContext);

            UrlProviderResolver.Current.InsertTypeBefore<DefaultUrlProvider, DemoUrlProvider>();
            UrlSegmentProviderResolver.Current.InsertTypeBefore<DefaultUrlSegmentProvider, DemoSegmentProvider>();
        }
    }
}