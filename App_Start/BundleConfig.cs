using System.Web;
using System.Web.Optimization;

namespace ClinicManager
{
    public class BundleConfig
    {
         public static void RegisterBundles(BundleCollection bundles)
        {
            //script bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/dtpickerjquery").Include(
                       "~/Scripts/jquery-ui-1.12.1.min.js",
                       "~/Scripts/jquery.datetimepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            //style bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/dtpickerstyles").Include(
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/jquery.datetimepicker.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
