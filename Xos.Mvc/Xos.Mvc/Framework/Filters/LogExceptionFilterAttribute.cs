using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Xos.Mvc.Framework.Filters
{
	public class LogExceptionFilterAttribute : IExceptionFilter
	{
		public void OnException( ExceptionContext filterContext )
		{
			// Log the exception here with your logging framework of choice.
		}
	}
}