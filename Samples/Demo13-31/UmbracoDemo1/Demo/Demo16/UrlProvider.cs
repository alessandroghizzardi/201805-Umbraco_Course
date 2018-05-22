using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Configuration;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace UmbracoDemo1.Demo.Demo16
{
    public class DemoUrlProvider : DefaultUrlProvider
    {
        public DemoUrlProvider()
          : base(UmbracoConfig.For.UmbracoSettings().RequestHandler)
        { }

        public override string GetUrl(UmbracoContext umbracoContext, int id, Uri current, UrlProviderMode mode)
        {
            string url = base.GetUrl(umbracoContext, id, current, mode);
            string tags = umbracoContext.HttpContext.Request.Params["tags"];

            if (string.IsNullOrEmpty(tags))
                return url;

            if (url.Contains('?'))
            {
                url += "&tags_rewritten=" + tags;
            }
            else
            {
                url += "?tags_rewritten=" + tags;
            }

            return url;
        }
        
    }
}