using System.Web.Mvc;

namespace Xos.Mvc.Framework.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Adds exception logging to the controller so that exceptions can be logged.
        /// This is a simplistic approach, tools such as ELMAH (https://elmah.github.io/) may be better candidates
        /// if a more fully featured logging engine is needed.
        /// </summary>
        /// <param name="filterContext"></param>
		protected override void OnException( ExceptionContext filterContext )
		{
            // Do additional things such as exception logging here.
            // Assuming that a LogErrorFile path and name has been set on the Settings object.

			// WriteLog( Settings.LogErrorFile, filterContext.Exception.ToString( ) );

			// Not sure if this is a good idea. Maybe the exception should not be handled.

			// filterContext.ExceptionHandled = true;
			// this.View( "Error" ).ExecuteResult( this.ControllerContext );

			// base.OnException( filterContext );
		}

		/// <summary>
		/// Logs a message to the given log file.
		/// </summary>
		/// <param name="logFile">The filename, including the path, write to.</param>
		/// <param name="text">The message to log.</param>
		static void WriteLog( string logFile, string text )
		{
            // Example of file based logging.
            // Use/Re-write code as needed.

            /*
             * StringBuilder message = new StringBuilder( );
             * message.AppendLine( DateTime.Now.ToString( ) );
             * message.AppendLine( text );
             * message.AppendLine( "=========================================" );
             * System.IO.File.AppendAllText( logFile, message.ToString( ) );
            */
		}

    }
}
