using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EmptyMvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery", 
            //    "https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js")
            //    .Include("~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;
        }
    }
}