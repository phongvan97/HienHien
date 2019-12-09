using System.Web;
using System.Web.Optimization;

namespace TayBac_28_06_17
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/js/jquery-3.1.1.min.js",
                        "~/Assets/js/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/othersjs").Include(
                    "~/Assets/js/material.min.js",
                    "~/Assets/js/perfect-scrollbar.jquery.min.js",
                    "~/Assets/js/jquery.validate.min.js",
                    "~/Assets/js/moment.min.js",
                    "~/Assets/js/chartist.min.js",
                    "~/Assets/js/jquery.bootstrap-wizard.js",
                    "~/Assets/js/bootstrap-notify.js",
                    "~/Assets/js/bootstrap-datetimepicker.js",
                    "~/Assets/js/jquery-jvectormap.js",
                    "~/Assets/js/nouislider.min.js",
                    "~/Assets/js/jquery.select-bootstrap.js",
                    "~/Assets/js/jquery.datatables.js",
                    "~/Assets/js/sweetalert2.js",
                    "~/Assets/js/jasny-bootstrap.min.js",
                    "~/Assets/js/fullcalendar.min.js",
                    "~/Assets/js/jspts/jquery.tagsinput.js",
                    "~/Assets/js/canvasjs.min.js",
                    "~/Assets/js/material-dashboard.js",
                    "~/Assets/js/demo.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assets/css/bootstrap.min.css",
                      "~/Assets/css/material-dashboard.css",
                      "~/Assets/css/site.css"));
        }
    }
}
