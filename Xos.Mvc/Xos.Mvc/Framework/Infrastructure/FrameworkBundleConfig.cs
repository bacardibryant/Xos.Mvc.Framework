using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Xos.Mvc.Framework.Infrastructure.FrameworkBundleConfig), "RegisterBundles")]

namespace Xos.Mvc.Framework.Infrastructure
{
    /// <summary>
    /// WebActivatorEx runs this RegisterBundles method after the normal ApplicationStart method.
    /// This method will register the Xos.Mvc Framework bundles adding the styles and scripts to the bundle table
    /// providing access to them in the application views.
    /// </summary>
	public class FrameworkBundleConfig
	{
		public static void RegisterBundles( )
		{
            // add css overrides. this is a mechanism for adding overrides to say a bootstrap theme
            // or some other template without modifying the base stylesheet.
            BundleTable.Bundles.Add(new StyleBundle( "~/framework/css/overrides" ).Include(
                "~/Framework/Content/overrides.css"));

            // attempt to load the jquery ui stylesheets if they have been loaded into the project.
            try
            {
                BundleTable.Bundles.Add(new StyleBundle("~/framework/css/optionals").Include(
                   "~/Content/themes/base/jquery-ui.css"));
            }
            catch {
                BundleTable.Bundles.Add(new StyleBundle("~/framework/css/optionals").Include(
                       "~/Framework/Content/styles-not-found.css"));
            }

            // jquery plugins and extensions. Assumes that the dependency scripts are referenced prior to this script reference.
            BundleTable.Bundles.Add( new ScriptBundle( "~/framework/scripts" ).Include(
                "~/Framework/Scripts/xos-js-exceptions.js",
                "~/Framework/Scripts/xos-js-extensions.js",
                "~/Framework/Scripts/jquery-form-defaults.js") );

            // attempt to load the jquery UI library if it has been add to the project.
            try
            {
                BundleTable.Bundles.Add(new ScriptBundle("~/framework/scripts/optionals").Include(
                    "~/Scripts/jquery-ui-{version}.js"));
            }
            catch {
                BundleTable.Bundles.Add(new ScriptBundle("~/framework/scripts/optionals").Include(
                    "~/Framework/Scripts/scripts-not-found.js"));
            }

            // the optimizations in ASP.NET bundling breaks jQuery UI.
            BundleTable.EnableOptimizations = false;
		}
	}
}