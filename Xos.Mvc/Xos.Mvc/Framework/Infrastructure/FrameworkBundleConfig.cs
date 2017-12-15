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

            // jquery plugins and extensions
			BundleTable.Bundles.Add( new ScriptBundle( "~/framework/scripts" ).Include(
				"~/Framework/Scripts/ux-tools.js",
                "~/Framework/Scripts/jquery-form-defaults.js",
				"~/Framework/Scripts/jquery.cookie.js",
                "~/Framework/Scripts/jquery.mask.js") );
		}
	}
}