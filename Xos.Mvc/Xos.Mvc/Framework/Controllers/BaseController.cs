using System.Web.Mvc;

namespace Xos.Mvc.Framework.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Adds exception logging to the controller so that exceptions can be logged.
        /// This is a simplistic approach, tools such as ELMAH might be better candidates for a
        /// more robust fully featured logging engine.
        /// </summary>
        /// <param name="filterContext"></param>
		protected override void OnException( ExceptionContext filterContext )
		{
			// Do additional things like logging here.
			// WriteLog( Settings.LogErrorFile, filterContext.Exception.ToString( ) );

			// Not sure if this needs to be called since base is executed.
			// maybe the exception should not be handled.
			// filterContext.ExceptionHandled = true;
			// this.View( "Error" ).ExecuteResult( this.ControllerContext );

			// base.OnException( filterContext );
		}

		/// <summary>
		/// Logs a message to the given log file
		/// </summary>
		/// <param name="logFile">The filename to log to</param>
		/// <param name="text">The message to log</param>
		static void WriteLog( string logFile, string text )
		{
            // Example of the type of file based logging.
            // Complete code as you see fit.

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
