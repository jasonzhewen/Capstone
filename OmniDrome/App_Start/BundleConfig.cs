using System.Web;
using System.Web.Optimization;

namespace OmniDrome
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                      "~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui-1.11.4.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                      "~/Content/themes/base/jquery.ui.core.css",
                      "~/Content/themes/base/jquery.ui.resizable.css",
                      "~/Content/themes/base/jquery.ui.selectable.css",
                      "~/Content/themes/base/jquery.ui.accordion.css",
                      "~/Content/themes/base/jquery.ui.autocomplete.css",
                      "~/Content/themes/base/jquery.ui.button.css",
                      "~/Content/themes/base/jquery.ui.dialog.css",
                      "~/Content/themes/base/jquery.ui.slider.css",
                      "~/Content/themes/base/jquery.ui.tabs.css",
                      "~/Content/themes/base/jquery.ui.datepicker.css",
                      "~/Content/themes/base/jquery.ui.progressbar.css",
                      "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/profile").Include(
                      "~/Content/themes/profile/Profile.css",
                      "~/Content/themes/profile/pastCircle.css",
                      "~/Content/themes/profile/Style.css"));

            bundles.Add(new ScriptBundle("~/bundles/zoomCircle").Include(
                      "~/Scripts/sylvester.js",
                      "~/Scripts/purecssmatrix.js",
                      "~/Scripts/jquery.animtrans.js",
                      "~/Scripts/jquery.zoomooz.js",
                      "~/Scripts/jquery.zoomooz.min.js"));
            
            bundles.Add(new StyleBundle("~/Content/timeline").Include(
                      "~/Content/themes/profile/reset.css",
                      "~/Content/themes/profile/timeLine.css"));

            bundles.Add(new ScriptBundle("~/bundles/timeline").Include(
                "~/Scripts/profile/timeLine.js",
                      "~/Scripts/profile/modernizr.js",
                      "~/Scripts/profile/jquery.mobile.custom.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-ui-router.min.js",
                      "~/Scripts/angular-input-date.js"));

            bundles.Add(new ScriptBundle("~/bundles/personalInfo").Include(
                      "~/Scripts/profile/personalInfo.js",
                      "~/Scripts/profile/Service.js",
                      "~/Scripts/profile/showInfo.js",
                      "~/Scripts/profile/addInfo.js",
                      "~/Scripts/profile/editInfo.js",
                      "~/Scripts/profile/editBackgroundInfo.js",
                      "~/Scripts/profile/showBackgroundInfo.js",
                      "~/Scripts/profile/addBackgroundInfo.js",
                      "~/Scripts/profile/deleteBackgroundInfo.js",
                      "~/Scripts/profile/showCurrentPosition.js",
                      "~/Scripts/profile/addCurrentPosition.js",
                      "~/Scripts/profile/editCurrentPosition.js"));
        }
    }
}
