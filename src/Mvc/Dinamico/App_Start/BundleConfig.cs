using System.Web;
using System.Web.Optimization;

namespace Dinamico
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery-bootstrap").Include(
                        "~/Dinamico/Themes/Metro/plugins/jquery-1.10.1.min.js",
                        "~/Dinamico/Themes/Metro/plugins/jquery-migrate-1.2.1.min.js",
                        "~/Dinamico/Themes/Metro/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js",
                        "~/Dinamico/Themes/Metro/plugins/bootstrap/js/bootstrap.min.js",
                        "~/Dinamico/Themes/Metro/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js"
                        ));

                        bundles.Add(new ScriptBundle("~/bundles/extras").Include(
                        "~/Dinamico/Themes/Metro/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Dinamico/Themes/Metro/plugins/jquery.blockui.min.js",
                        "~/Dinamico/Themes/Metro/plugins/jquery.cookie.min.js",
                        "~/Dinamico/Themes/Metro/plugins/uniform/jquery.uniform.min.js",
                        "~/Dinamico/Themes/Metro/plugins/metro-panel/source/js/openpanel.min.js",
                        "~/Dinamico/Themes/Metro/plugins/metro-panel/source/js/jscrollpane/jquery.jscrollpane.min.js",
                        "~/Dinamico/Themes/Metro/plugins/metro-panel/source/js/jscrollpane/jquery.mousewheel.min.js",
                        "~/Dinamico/Themes/Metro/scripts/custom.js",
                        "~/Dinamico/Themes/Metro/scripts/app.js"
                        ));


            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Dinamico/Themes/Metro/plugins/bootstrap/css/bootstrap.min.css",
                "~/Dinamico/Themes/Metro/plugins/bootstrap/css/bootstrap-responsive.min.css",
                "~/Dinamico/Themes/Metro/plugins/font-awesome/css/font-awesome.min.css",
                "~/Dinamico/Themes/Metro/css/style-metro.css",
                "~/Dinamico/Themes/Metro/css/style.css",
                "~/Dinamico/Themes/Metro/css/style-responsive.css",
                "~/Dinamico/Themes/Metro/plugins/uniform/css/uniform.default.css",
                "~/Dinamico/Themes/Metro/css/pages/blog.css",
                "~/Dinamico/Themes/Metro/plugins/metro-panel/source/css/openpanel-custom.css"
                ));


            bundles.Add(new StyleBundle("~/content/css-overrides").Include(
                "~/Dinamico/Themes/Metro/css/overrides.css"
                ));

            bundles.Add(new StyleBundle("~/content/blue").Include("~/Dinamico/Themes/Metro/css/themes/blue.css"));
            bundles.Add(new StyleBundle("~/content/brown").Include("~/Dinamico/Themes/Metro/css/themes/brown.css"));
            bundles.Add(new StyleBundle("~/content/default").Include("~/Dinamico/Themes/Metro/css/themes/default.css"));
            bundles.Add(new StyleBundle("~/content/grey").Include("~/Dinamico/Themes/Metro/css/themes/grey.css"));
            bundles.Add(new StyleBundle("~/content/light").Include("~/Dinamico/Themes/Metro/css/themes/light.css"));
            bundles.Add(new StyleBundle("~/content/purple").Include("~/Dinamico/Themes/Metro/css/themes/purple.css"));
        }
    }
}