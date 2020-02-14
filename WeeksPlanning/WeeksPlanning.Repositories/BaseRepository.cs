using System;
using System.Linq;
using System.Linq.Expressions;
using WeeksPlanning.Core.Core;

namespace WeeksPlanning.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public long GetCount()
        {
            throw new NotImplementedException();
        }

        public long GetCount(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}