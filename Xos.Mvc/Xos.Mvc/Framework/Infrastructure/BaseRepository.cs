/*
 * Repository pattern based on the blog post
 * "How to Work With Generic Repositories on ASP.NET MVC and Unit Testing Them By Mocking"
 * http://www.tugberkugurlu.com/archive/how-to-work-with-generic-repositories-on-asp-net-mvc-and-unit-testing-them-by-mocking
 * Tugberk Ugurlu 2011
 */
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Xos.Mvc.Framework.Infrastructure
{
    /// <summary>
    /// Base Repostiory implemented as an abstract class. Allows all virtual methods to be overridden in the derived class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> where T:class
    {
        private BaseDbContext _context;
        
        public BaseDbContext Context
        {
            get => _context;
            set => _context = value;
        }

        /// <summary>
        /// Creates an instance of the backing repository and provides methods for making context calls using the generic model
        /// passed in from the derived repository class.
        /// </summary>
        /// <param name="context">The DbContext to be used for the EF calls. The application level DbContext must be derived from the Framework/Infrastructure/BaseDbContext class.</param>
        public BaseRepository(BaseDbContext context) => Context = context;

        public virtual IQueryable<T> GetAll() {
           IQueryable<T> query = _context.Set<T>();
           return query;
        }

        /// <summary>
        /// FindBy returns the IQueryable<typeparamref name="T"/> that matches the <paramref name="predicate"/>.
        /// Instead of using defined a <see langword="property"/> in <see cref="FindBy"/>,
        /// one <see langword="method"/> can be implemented on the repository that can match on any expression.
        /// This allows <see cref="FindBy"/> to be used to match on any <see langword="property"/> of the class.
        /// </summary>
        /// <example>
        /// <see cref="FindBy(Expression{Func{T, bool}})"/> can be used in a controller as such:
        /// <code>
        /// public class WidgetController : Controller
        /// {
        ///     private readonly IBaseRepository<Widget> _repository;

        ///     public WidgetController(BaseRepository<Widget> repository)
        ///     {
        ///         _repository = repository;
        ///     }

        ///     public ActionResult GetWidgetByCategory(string category)
        ///     {
        ///         var viewModel = new WidgetsViewMode {
        ///             Widgets = _repository.FindBy(w => w.Category == category);
        ///         }
        ///         
        ///         return View(viewModel);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <param name="predicate">An expression containing the parameters to match.</param>
        /// <typeparam name="T">The model type of the collection to be returned.</typeparam>
        /// <returns>IQueryable<typeparamref name="T"/> which represents all entities that matched the predicate.</returns>
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}