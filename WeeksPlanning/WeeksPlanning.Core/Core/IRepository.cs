using System;
using System.Linq;
using System.Linq.Expressions;

namespace WeeksPlanning.Core.Core
{
    public interface IRepository<T> where T : class
    {
        long GetCount();
        long GetCount(Expression<Func<T, bool>> expression);
        IQueryable<T> Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Add(T entity);
        IQueryable<T> Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
    }
}