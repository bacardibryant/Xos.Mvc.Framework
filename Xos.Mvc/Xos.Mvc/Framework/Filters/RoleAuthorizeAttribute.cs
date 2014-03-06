using System;
using System.Web.Mvc;

namespace Xos.Mvc.Framework.Filters
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        private string _redirectUrl = "";
        public string RedirectUrl {
            get { return _redirectUrl; }
            set { _redirectUrl = value; }
        }
        public RoleAuthorizeAttribute()
        {
        }

        public RoleAuthorizeAttribute(string redirectUrl)
        {
            _redirectUrl = redirectUrl;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var authUrl = _redirectUrl; //passed from attribute

                //if null, get it from config
                if (String.IsNullOrEmpty(authUrl))
                    authUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["RolesAuthRedirectUrl"];

                if (!String.IsNullOrEmpty(authUrl))
                    filterContext.HttpContext.Response.Redirect(authUrl);
            }

            //else do normal process
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}