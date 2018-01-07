/*
 * Repository pattern based on the blog post
 * "How to Work With Generic Repositories on ASP.NET MVC and Unit Testing Them By Mocking"
 * http://www.tugberkugurlu.com/archive/how-to-work-with-generic-repositories-on-asp-net-mvc-and-unit-testing-them-by-mocking
 * Tugberk Ugurlu 2011
 */
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Xos.Mvc.Framework.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        void Save();
    }
}