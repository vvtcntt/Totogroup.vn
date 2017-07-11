using System.Web;
using System.Web.Optimization;

namespace TOTOGROUP
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

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
            bundles.Add(new StyleBundle("~/Content/Display/Css/Style").Include(
                    "~/Content/Display/Css/Data.css",
       "~/Content/Display/Css/Index.css",
       "~/Content/Display/Css/Index_Rs.css",
       "~/Content/Display/Css/jquery.mmenu.all.css",
       "~/Content/Display/Css/News.css",
       "~/Content/Display/Css/News_Rs.css",
       "~/Content/Display/Css/Order.css",
       "~/Content/Display/Css/Order_res.css",
       "~/Content/Display/Css/prettyPhoto.css",
       "~/Content/Display/Css/Product.css",
       "~/Content/Display/Css/Product_Rs.css",
       "~/Content/Display/Css/Maps.css",
       "~/Content/Display/Css/linhnguyen.css",
       "~/Content/Display/Css/styles.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}