using System;
using System.Linq;
using System.Linq.Expressions;

namespace WeeksPlanning.Core.Core
{
    public interface IRepository<T> where T : class
    {
        long GetCount();
        long GetCount(Expression<Func<T, bool>> expression);
        IQueryable<T> Get(long id);
        IQueryable<T> GetAll();
        IQueryable<T> Add(T entity);
        IQueryable<T> Update(T entity);
        void Delete(T entity);
        void Delete(long id);
    }
}