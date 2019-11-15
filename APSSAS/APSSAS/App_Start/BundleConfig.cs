using System.Web.Optimization;

namespace APSSAS.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region StylesBundle
            bundles.Add(new StyleBundle("~/Content/Default").Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/Home").Include("~/Content/Home/Index.css"));
            #endregion

            #region ScriptBundle
            bundles.Add(new ScriptBundle("~/Scripts/Default").Include("~/Scripts/jquery-2.1.1.min.js").Include("~/Scripts/materialize/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include("~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Home").Include("~/Scripts/Home/Index.js"));
            #endregion
        }
    }
}