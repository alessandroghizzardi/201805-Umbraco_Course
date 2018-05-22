using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmptyMvc.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            Log(methodName, routeData, string.Empty);
        }
        private void Log(string methodName, RouteData routeData, string alert)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);

            string filePath = string.Format("/App_Data/{0}-LogActionFilter.log",
                DateTime.Today.ToString("yyyy-MM-dd"));

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                System.Web.HttpContext.Current.Server.MapPath(filePath), true))
            {
                sw.WriteLine(string.Format("{0} - {1}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                    string.IsNullOrEmpty(alert) ? message : string.Format("{0} - {1}", message, alert)));
            }
        }

    }
}