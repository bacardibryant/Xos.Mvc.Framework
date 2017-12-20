using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Xos.Mvc.Framework.Infrastructure
{
    public abstract class BaseRepository<C, T> :
        IBaseRepository<T> where T : class where C : BaseDbContext, new()
    {
        private C _context = new C();

        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }


        public virtual IQueryable<T> GetAll() {
           IQueryable<T> query = _context.Set<T>();
           return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
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
    }
}