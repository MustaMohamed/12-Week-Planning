using System;
using System.Linq;
using System.Linq.Expressions;
using DependencyInjection.Config.Attributes;
using ORM;
using WeeksPlanning.Core.Repositories;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Repositories
{
    [CreateInScope]
    public class PlanRepository : IPlanRepository
    {
        public long GetCount()
        {
            return Query.Get(meta => meta.Plan.LongCount());
        }

        public long GetCount(Expression<Func<PlanEntity, bool>> expression)
        {
            return Query.Get(meta => meta.Plan.Where(expression).LongCount());
        }

        public IQueryable<PlanEntity> Get(long id)
        {
            return Query.Get(meta => meta.Plan.Where(p => p.Id == id));
        }

        public IQueryable<PlanEntity> GetAll()
        {
            return Query.Get(meta => meta.Plan);
        }

        public IQueryable<PlanEntity> Add(PlanEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PlanEntity> Update(PlanEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PlanEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}