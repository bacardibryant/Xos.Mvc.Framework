using System.Configuration;
using System.Data.Entity;

namespace Xos.Mvc.Framework.Infrastructure
{
	public class BaseDbContext : DbContext
	{
		public BaseDbContext(string connectionStringName )
		{
			// set the connection string.
			Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings[ connectionStringName ].ConnectionString;
        }

    }
}