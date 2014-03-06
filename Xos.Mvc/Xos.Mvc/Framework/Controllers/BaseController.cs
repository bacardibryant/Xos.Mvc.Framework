using System.Web.Mvc;

namespace Xos.Mvc.Framework.Controllers
{
    public class BaseController : Controller
    {
		protected override void OnException( ExceptionContext filterContext )
		{
			// Do additional things like logging here.
			//WriteLog( Settings.LogErrorFile, filterContext.Exception.ToString( ) );

			// not sure if this needs to be called since base is executed.
			// maybe the exception should not be handled.
			//filterContext.ExceptionHandled = true;
			//this.View( "Error" ).ExecuteResult( this.ControllerContext );

			//base.OnException( filterContext );
		}

		/// <summary>
		/// Logs a message to the given log file
		/// </summary>
		/// <param name="logFile">The filename to log to</param>
		/// <param name="text">The message to log</param>
		static void WriteLog( string logFile, string text )
		{
			//TODO: Format nicer
			//StringBuilder message = new StringBuilder( );
			//message.AppendLine( DateTime.Now.ToString( ) );
			//message.AppendLine( text );
			//message.AppendLine( "=========================================" );
			//System.IO.File.AppendAllText( logFile, message.ToString( ) );
		}

    }
}
