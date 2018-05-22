using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Strings;

namespace UmbracoDemo1.Demo.Demo16
{
    public class DemoSegmentProvider : IUrlSegmentProvider
    {
        readonly IUrlSegmentProvider _provider = new DefaultUrlSegmentProvider();
        
        public string GetUrlSegment(IContentBase content)
        {
            if (content.ContentTypeId != 1057) return null;
            var segment = _provider.GetUrlSegment(content);
            return string.Format("{0}-{1}", content.Id, segment);
        }
        

        public string GetUrlSegment(IContentBase content, CultureInfo culture)
        {
            var segment = _provider.GetUrlSegment(content, culture);
            return segment;
        }
    }
}