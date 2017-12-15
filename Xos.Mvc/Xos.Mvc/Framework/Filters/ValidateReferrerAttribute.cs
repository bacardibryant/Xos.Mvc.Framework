using System.Web;
using System.Web.Mvc;

namespace Xos.Mvc.Framework.Filters
{
    /// <summary>
    /// A useful attribute that can be used to authorize access to a route.
    /// When applied to controllers with post action methods, the referring domain can be verified.
    /// If the referrer is not on the approved list, then the submission can be ignored or handled however decided.
    /// </summary>
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
