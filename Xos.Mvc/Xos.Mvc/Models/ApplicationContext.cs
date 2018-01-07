using System.Data.Entity;
using Xos.Mvc.Framework.Infrastructure;

namespace Xos.Mvc.Models
{
    /// <summary>
    /// Application level DbContext that must derive from Framework/Infrastructure/BaseDbContext which accepts the connection string name as a constructor parameter,
    /// or a parameterless constructor call.
    /// </summary>
    public class ApplicationContext : BaseDbContext
    {
        public ApplicationContext():base(){}
        public ApplicationContext(string connectionStringName) : base(connectionStringName) { }

        public DbSet<SampleModel> SampleModels { get; set; }
    }
}