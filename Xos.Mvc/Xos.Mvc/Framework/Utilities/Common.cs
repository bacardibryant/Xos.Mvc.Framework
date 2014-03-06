using System.IO;
using System.Web.Mvc;

namespace Xos.Mvc.Framework.Utilities
{
    public class Common
    {
        internal static string ToHtml(string viewToRender, ViewDataDictionary viewData, ControllerContext controllerContext)
        {
            var result = ViewEngines.Engines.FindView(controllerContext, viewToRender, null);

            var output = new StringWriter();
            var viewContext = new ViewContext(controllerContext, result.View, viewData, controllerContext.Controller.TempData, output);
            result.View.Render(viewContext, output);
            result.ViewEngine.ReleaseView(controllerContext, result.View);

            return output.ToString();
        }
    }
}