using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace TryCatch.Web.Shop
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
                      "~/Scripts/lodash.js",
                      "~/Scripts/react/react.js",
                      "~/Scripts/react/react-dom.js",
                      "~/Scripts/js.cookie.js",
                      "~/Scripts/common.js"));


            bundles.Add(new BabelBundle("~/bundles/components")
                .IncludeDirectory("~/Scripts/Components/Common", "*.jsx")
                .IncludeDirectory("~/Scripts/Components/Product", "*.jsx")
                .IncludeDirectory("~/Scripts/Components/Cart", "*.jsx")
                .IncludeDirectory("~/Scripts/Components/Order", "*.jsx")
                .Include("~/Scripts/Components/Home.jsx"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
