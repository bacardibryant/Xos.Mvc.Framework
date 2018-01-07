using System.Configuration;
using System.Data.Entity;

namespace Xos.Mvc.Framework.Infrastructure
{
    /// <summary>
    /// BaseDbContext with two constructors. The empty constructor allows the default behaviour in using the derived class name as the name of the connection string.
    /// The second constructor allows a connection string name to be passed in which adds flexibility.
    /// </summary>
	public class BaseDbContext : DbContext
	{
        public BaseDbContext(){}
        public BaseDbContext(string connectionStringName) => Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
    }
}