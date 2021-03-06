﻿using System.Web;
using System.Web.Optimization;

namespace dance_club
{
    public class BundleConfig
    {
       
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

          
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/bootstrap-grid.css",
                      "~/Content/site.css",
                       "~/Content/font-awesome.css", 
                       "~/Content/bootstrap-datetimepicker.css"));
        }
    }
}
