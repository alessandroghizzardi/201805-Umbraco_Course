using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;

namespace UmbracoDemo1.Demo.Demo30
{
    [HealthCheck("9C508E12-D74C-4901-8C3C-1219299F5372", "Robots.txt",
    Description = "Create a robots.txt file to block access to system folders.",
    Group = "SEO")]
    public class RobotsTxt : HealthCheck
    {
        private readonly ILocalizedTextService _textService;

        public RobotsTxt(HealthCheckContext healthCheckContext) : base(healthCheckContext)
        {
            _textService = healthCheckContext.ApplicationContext.Services.TextService;
        }

        /// <summary>
        /// Status method
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<HealthCheckStatus> GetStatus()
        {
            return new[] { CheckForRobotsTxtFile() };
        }

        public override HealthCheckStatus ExecuteAction(HealthCheckAction action)
        {
            switch (action.Alias)
            {
                case "addDefaultRobotsTxtFile":
                    return AddDefaultRobotsTxtFile();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private HealthCheckStatus CheckForRobotsTxtFile()
        {
            var success = File.Exists(HttpContext.Current.Server.MapPath("~/robots.txt"));
            var message = success
                ? _textService.Localize("healthcheck/seoRobotsCheckSuccess")
                : _textService.Localize("healthcheck/seoRobotsCheckFailed");

            var actions = new List<HealthCheckAction>();

            if (success == false)
                actions.Add(new HealthCheckAction("addDefaultRobotsTxtFile", Id)
                // Override the "Rectify" button name and describe what this action will do
                {
                    Name = _textService.Localize("healthcheck/seoRobotsRectifyButtonName"),
                    Description = _textService.Localize("healthcheck/seoRobotsRectifyDescription")
                });

            return
                new HealthCheckStatus(message)
                {
                    ResultType = success ? StatusResultType.Success : StatusResultType.Error,
                    Actions = actions
                };
        }

        private HealthCheckStatus AddDefaultRobotsTxtFile()
        {
            var success = false;
            var message = string.Empty;
            const string content = @"# robots.txt for Umbraco
User-agent: *
Disallow: /umbraco/";

            try
            {
                File.WriteAllText(HostingEnvironment.MapPath("~/robots.txt"), content);
                success = true;
            }
            catch (Exception exception)
            {
                LogHelper.Error<RobotsTxt>("Could not write robots.txt to the root of the site", exception);
            }

            return
                new HealthCheckStatus(message)
                {
                    ResultType = success ? StatusResultType.Success : StatusResultType.Error,
                    Actions = new List<HealthCheckAction>()
                };
        }
    }
}