using System.Web;
using System.Web.Optimization;

namespace Tracker
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                        .Include("~/Scripts/jquery-{version}.js")
                        .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                        .Include("~/Scripts/globalize/globalize.js")
                        .Include("~/Scripts/globalize/cultures/globalize.culture.en-GB.js")
                        
                        );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include(
                "~/Scripts/jquery.validate.js", 
                "~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/jquery.validate.globalize.js")
                );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-datepicker-globalize.js")
                      );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-slate.css",
                      "~/Content/datepicker.css",
                      "~/Content/site.css"));
        }
    }
}
