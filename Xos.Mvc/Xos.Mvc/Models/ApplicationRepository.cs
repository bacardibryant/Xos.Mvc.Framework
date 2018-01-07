using Xos.Mvc.Framework.Infrastructure;

namespace Xos.Mvc.Models
{
    public class ApplicationRepository<T> : BaseRepository<T> where T:class
    {
        /// <summary>
        /// <see cref="ApplicationRepository"/> constructor which passes an instance of the <see cref="ApplicationContext"/> to the <see cref="BaseRepository"/>.
        /// This allows for the consuming repository to pass in names for and instantiate different context objects if needed.
        /// The <see cref="BaseRepository"/> implements the CRUD methods against the <see langword="DbContext"/> as well as calls the <see cref="Dispose"/> method on the DbContext.
        /// </summary>
        public ApplicationRepository(BaseDbContext context):base(context){}

    }
}