using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(BT.App_Start.MetroUICSSBundleConfig), "RegisterBundles")]

namespace BT.App_Start
{
	public class MetroUICSSBundleConfig
	{
        public static void RegisterBundles(BundleCollection bundles)
		{
			// Add @Styles.Render("~/Content/metro-ui/css") in the <head/> of your _Layout.cshtml view
			// Add @Scripts.Render("~/bundles/metro-ui") after jQuery in your _Layout.cshtml view
			// When <compilation debug="true" />, ASP.Net will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            bundles.Add(new ScriptBundle("~/bundles/metro-ui").Include("~/Scripts/metro-ui/jquery.ui.widget.js").Include("~/Scripts/metro-ui/metro.min.js"));
            bundles.Add(new StyleBundle("~/Content/metro-ui/css").Include("~/Content/metro-ui/css/metro-bootstrap.css", "~/Content/metro-ui/css/metro-bootstrap-responsive.css", "~/Content/metro-ui/css/iconFont.min.css"));
		}
	}
}
