﻿using System.Web.Optimization;
using System.Web.Optimization.React;

namespace TryCatchWebShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/react/react.js",
                      "~/Scripts/react/react-dom.js",
                      "~/Scripts/js.cookie.js"));

            
            //bundles.Add(new BabelBundle("~/bundles/components/product")
            //    .IncludeDirectory("~/Scripts/Components/Product", "*.jsx"));

            //        bundles.Add(new ScriptBundle("~/bundles/components/product")
            //.IncludeDirectory("~/Scripts/Components/Product", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}