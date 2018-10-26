using System.Web;
using System.Web.Optimization;

namespace ATAarhitektonskiStudio
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();
            bundles.ResetAll();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/umd/popper.js",
                      "~/Scripts/bootstrap.js"));

            /*USER BUNDLES*/
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/userCss").Include(
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/userScripts").Include(
                       "~/Content/Scripts/multiLanguajeDemo.js",
                       "~/Content/Scripts/globalJS.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeScript").Include(
                      "~/Scripts/userScripts/homepage.js"));

            bundles.Add(new ScriptBundle("~/bundles/contactScript").Include(
                      "~/Content/Scripts/contact.js"));

            bundles.Add(new ScriptBundle("~/bundles/projectScript").Include(
                     "~/Content/Scripts/owl-carousel.js",
                     "~/Content/Scripts/lightbox.js",
                     "~/Content/Scripts/projects.js"));

            bundles.Add(new StyleBundle("~/Content/projectCss").Include(
                      "~/Content/owl-carousel.css",
                      "~/Content/owl-carousel-theme.css",
                      "~/Content/lightbox.css"));

            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                       "~/Content/font-awesome5.css", new CssRewriteUrlTransform()
                       ));

            /*ADMIN BUNDLES*/

            bundles.Add(new StyleBundle("~/Content/adminCss").Include(
                      "~/Areas/Admin/Content/css/bootstrap.css",
                      "~/Areas/Admin/Content/css/style.css",
                      "~/Areas/Admin/Content/css/font-awesome.css",
                      "~/Content/summernote.css",
                      "~/Areas/Admin/Content/css/jquery.filer-dragdropbox-theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminScripts").Include(
                        "~/Areas/Admin/Content/js/popper.min.js",
                        "~/Areas/Admin/Content/js/tether.min.js",
                        "~/Areas/Admin/Content/js/bootstrap.js",
                        "~/Areas/Admin/Content/js/pikeadmin.js",
                        "~/Areas/Admin/Content/js/moment.min.js",
                        "~/Areas/Admin/Content/js/detect.js",
                        "~/Areas/Admin/Content/js/fastclick.js",
                        "~/Areas/Admin/Content/js/jquery.blockUI.js",
                        "~/Areas/Admin/Content/js/jquery.nicescroll.js",
                        "~/Areas/Admin/Content/js/switchery.min.js",
                        "~/Scripts/summernote/summernote.js",
                        "~/Scripts/summernote/summernote-ext-specialchars.js",
                        "~/Scripts/jquery-ui-1.12.1.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
