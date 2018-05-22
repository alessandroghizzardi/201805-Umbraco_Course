using System;
using System.Globalization;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Routing;
using System.Linq;
using Umbraco.Core;

namespace UmbracoDemo1.Demo.Demo15
{
    public class Demo404ContentFinder : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            IPublishedContent rootNode = UmbracoContext.Current.ContentCache.GetByXPath("root/homepage").FirstOrDefault();
            //Must create 404 alias
            IPublishedContent notFoundNode = UmbracoContext.Current.ContentCache.GetByXPath("root/homepage/notFound").FirstOrDefault();

            if (notFoundNode != null)
            {
                contentRequest.PublishedContent = notFoundNode;
            }
            else if (rootNode != null)
            {
                contentRequest.PublishedContent = rootNode;
            }
            else
            {
                contentRequest.PublishedContent = UmbracoContext.Current.ContentCache.GetAtRoot().FirstOrDefault(n => n.GetTemplateAlias() != "");
            }

            return contentRequest.PublishedContent != null;
        }
    }

    public class DemoHandleWootContentFinder : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            var path = contentRequest.Uri.GetAbsolutePathDecoded();
            if (path.StartsWith("/woot"))
            {
                IPublishedContent rootNode = UmbracoContext.Current.ContentCache.GetByXPath("root/homepage").FirstOrDefault();

                contentRequest.PublishedContent = rootNode;

                return true; //return home
            }
            return false;
        }
    }
}
