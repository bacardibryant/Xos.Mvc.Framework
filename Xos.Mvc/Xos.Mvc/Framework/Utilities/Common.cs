using System.IO;
using System.Web.Mvc;

namespace Xos.Mvc.Framework.Utilities
{
    /// <summary>
    /// This code was adopted from StackOverflow as it was a commonly accepted solution for rendering views into html strings.
    /// The output can then be used to set the MailMessage.Body property with the MailMessage.IsBodyHtml property set to true
    /// resulting in an html message being programmatically sent.
    /// </summary>
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