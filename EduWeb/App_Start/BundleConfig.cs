﻿using System.Web;
using System.Web.Optimization;

namespace EduWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                        "~/Content/tinymce/tinymce.min.js",
                        "~/Content/tinymce/config.js"));

            bundles.Add(new ScriptBundle("~/Areas/Admin/Content/javascript").Include(
                  "~/Areas/Admin/Content/plugins/jquery/jquery.min.js",
                  "~/Areas/Admin/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                  "~/Areas/Admin/Content/plugins/chart.js/Chart.min.js",
                  "~/Areas/Admin/Content/plugins/sparklines/sparkline.js",
                  "~/Areas/Admin/Content/plugins/jqvmap/jquery.vmap.min.js",
                  "~/Areas/Admin/Content/plugins/jqvmap/maps/jquery.vmap.usa.js",
                  "~/Areas/Admin/Content/plugins/jquery-knob/jquery.knob.min.js",
                  "~/Areas/Admin/Content/plugins/moment/moment.min.js",
                  "~/Areas/Admin/Content/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                  "~/Areas/Admin/Content/plugins/summernote/summernote-bs4.min.js",
                  "~/Areas/Admin/Content/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                  "~/Areas/Admin/Content/dist/js/adminlte.js",
                  "~/Areas/Admin/Content/dist/js/pages/dashboard.js",
                  "~/Areas/Admin/Content/dist/js/demo.js",
                  "~/Areas/Admin/Content/plugins/daterangepicker/daterangepicker.js",
                  "~/Areas/Admin/Content/plugins/jquery-ui/jquery-ui.min.js",
                  "~/Areas/Admin/Content/dist/js/adminlte.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Areas/Admin/Content/css").Include(
                      "~/Areas/Admin/Content/plugins/fontawesome-free/css/all.min.css",
                      "~/Areas/Admin/Content/dist/css/ionicons.min.css",
                      "~/Areas/Admin/Content/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                      "~/Areas/Admin/Content/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                      "~/Areas/Admin/Content/plugins/jqvmap/jqvmap.min.css",
                      "~/Areas/Admin/Content/dist/css/adminlte.min.css",
                      "~/Areas/Admin/Content/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                      "~/Areas/Admin/Content/plugins/daterangepicker/daterangepicker.css",
                      "~/Areas/Admin/Content/plugins/summernote/summernote-bs4.css"));
        }
    }
}
