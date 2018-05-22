using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;
using Umbraco.Web.HealthCheck.Checks.Config;

namespace UmbracoDemo1.Demo.Demo30
{
    [HealthCheck("3BEDE447-82BA-4756-A18D-76AE11D14B81", "Demo Macro errors",
         Description = "Demo macro error check description",
         Group = "Configuration")]
    public class DemoCustomConfigurationCheck : AbstractConfigCheck
    {
        public DemoCustomConfigurationCheck(HealthCheckContext healthCheckContext) : base(healthCheckContext)
        {
            _textService = healthCheckContext.ApplicationContext.Services.TextService;
        }

        public override string FilePath
        {
            get { return "~/Config/umbracoSettings.config"; }
        }

        public override string XPath
        { 
             get { return "/settings/content/MacroErrors"; }
        }

        public override IEnumerable<AcceptableConfiguration> Values
        {
            get
            {
                var values = new List<AcceptableConfiguration>
                 {
                     new AcceptableConfiguration
                     {
                         IsRecommended = true,
                         Value = "inline"
                     },
                     new AcceptableConfiguration
                     {
                         IsRecommended = false,
                         Value = "silent"
                     }
                 };

                return values;
            }
        }

        public override ValueComparisonType ValueComparisonType
        {
            get { return ValueComparisonType.ShouldEqual; }
        }

        private readonly ILocalizedTextService _textService;

        public override string CheckSuccessMessage
        {
            get
            {
                return _textService.Localize("healthcheck/demoMacroErrorModeCheckSuccessMessage",
                    new[] { CurrentValue, Values.First(v => v.IsRecommended).Value });
            }
        }

        public override string CheckErrorMessage
        {
            get
            {
                var test = _textService.Localize("healthcheck/demoMacroErrorModeCheckErrorMessage");

                var res = _textService.Localize("healthcheck/demoMacroErrorModeCheckErrorMessage",
                    new[] { CurrentValue, Values.First(v => v.IsRecommended).Value });
                return res;
            }
        }

        public override string RectifySuccessMessage
        {
            get
            {
                return _textService.Localize("healthcheck/demoMacroErrorModeCheckRectifySuccessMessage",
                    new[] { Values.First(v => v.IsRecommended).Value });
            }
        }
    }
}