using System.Web;
using System.Web.Optimization;

namespace TestDemoMVCCodeFirst
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/bootstrap-theme.css")
                .Include("~/Content/bootstrap-theme.css.map")
                .Include("~/Content/bootstrap-theme.min.css")
                .Include("~/Content/bootstrap-theme.min.css.map")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap.css.map")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap.min.css.map")
                .Include("~/Content/Site.css")
                .Include("~/Content/css/select2.css")
                .Include("~/Content/css/select2.min.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/jquery-3.7.1.js")
                .Include("~/Scripts/jquery-3.7.1.min.js")
                .Include("~/Scripts/jquery-3.7.1.slim.js")
                .Include("~/Scripts/jquery.validate-vsdoc.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/modernizr-2.8.3.js")
                .Include("~/Scripts/select2.js")
                .Include("~/Scripts/select2.min.js")
                .Include("~/Scripts/select2.full.min.js"));

        }
    }
}
