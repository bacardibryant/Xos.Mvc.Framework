using System.Web;
using System.Web.Mvc;

namespace Xos.Mvc.Framework.Filters
{
    public class ValidateReferrerAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext != null)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null)
                {
                    throw new HttpException("Invalid Submission");
                }
                if (filterContext.HttpContext.Request.UrlReferrer.Host != "{example.com}")
                {
                    throw new HttpException("InvalidSubmission");
                }
            }
            base.OnAuthorization(filterContext);
        }

    }
}
