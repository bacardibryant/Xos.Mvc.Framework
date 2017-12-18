using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xos.Mvc.Framework.Controllers;
using Xos.Mvc.Framework.Filters;

namespace Xos.Mvc.Controllers
{
    // Example of how to inherit from the framework classes
    public class HomeController : BaseController
    {
        // GET: Home
        // Example of the application of the LogAttribute. If there was a logging implementation in the attribute filter, then it would execute
        // when this action is called. This could be applied at the controller scope (all actions in the controller) or the controller action scope.
        [Log]
        public ActionResult Index()
        {
            return View();
        }
    }
}