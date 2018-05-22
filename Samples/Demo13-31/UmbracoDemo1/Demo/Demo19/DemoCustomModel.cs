using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace UmbracoDemo1.Demo.Demo19

{
    public class DemoCustomModel : RenderModel
    {
        public DemoCustomModel(IPublishedContent content) : base(content) { }

        public string MyCustomProperty { get; set; }
    }
}