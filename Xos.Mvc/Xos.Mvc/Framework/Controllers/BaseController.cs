using System.Web.Mvc;

namespace Xos.Mvc.Framework.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() {}

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
            }

            // Free any unmanaged objects here.
            //
            disposed = true;

            // Call the base class implementation.
            base.Dispose(disposing);
        }

        ~BaseController()
        {
            Dispose(false);
        }
    }
}
