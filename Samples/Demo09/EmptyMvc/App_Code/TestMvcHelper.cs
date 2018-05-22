using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class TestMvcHelper
{
    public static IHtmlString PrefilledTextbox(string id, string value)
    {
        return
            MvcHtmlString.Create(string.Format("<input type=\"text\" id=\"{0}\" value=\"{1}\" style=\"width: 500px;\"/>", id, value));
    }
}

public static class TestMvcHelperExtension
{
    public static IHtmlString PrefilledTextbox(this HtmlHelper helper, string id, string value)
    {
        return
            MvcHtmlString.Create(string.Format("<input type=\"text\" id=\"{0}\" value=\"{1}\" style=\"width: 500px;\"/>", id, value));
    }
}