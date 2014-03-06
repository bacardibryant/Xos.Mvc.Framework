using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Xos.Mvc.Framework.Infrastructure.FrameworkBundleConfig), "RegisterBundles")]

namespace Xos.Mvc.Framework.Infrastructure
{
	public class FrameworkBundleConfig
	{
		public static void RegisterBundles( )
		{
            // add css overrides. this is a mechanism for adding overrides to say a bootstrap theme
            // or some other template without modifying the base stylesheet.
            BundleTable.Bundles.Add(new StyleBundle( "~/framework/css/overrides" ).Include(
                "~/Framework/Content/overrides.css"));

            //browser based overrides. same principle as above but browser specific.
            BundleTable.Bundles.Add(new StyleBundle("~/framework/css/ie8overrides").Include(
                "~/Framework/Content/overrides-ie8.css"));

            // jquery plugins and extensions
			BundleTable.Bundles.Add( new ScriptBundle( "~/framework/scripts" ).Include(
				"~/Framework/Scripts/ux-tools.js",
                "~/Framework/Scripts/jquery-form-defaults.js",
				"~/Framework/Scripts/jquery.cookie.js",
                "~/Framework/Scripts/jquery.mask.js") );

            // add html5 support to applications.
            BundleTable.Bundles.Add(new ScriptBundle( "~/framework/scripts/html5shiv" ).Include(
                "~/Framework/Scripts/html5shiv.js",
                "~/Framework/Scripts/html5shiv-printshiv.js"));

            // the popular respond polyfill
            BundleTable.Bundles.Add(new ScriptBundle( "~/framework/scripts/respond" ).Include(
                "~/Framework/Scripts/respond.js"));
		}
	}
}