using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMvc.App_Code
{
    public static class MvcImageHelper
    {
        public static IHtmlString ViewUploadedImage(this HtmlHelper htmlHelper, string imageName)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", System.IO.Path.Combine("/Uploads", imageName));
            img.MergeAttribute("alt", "Saved from MVC");
            return new HtmlString(img.ToString(TagRenderMode.SelfClosing));
        }
    }
}