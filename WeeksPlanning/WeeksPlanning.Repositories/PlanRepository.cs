using System;
using System.Collections.Generic;
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
            return OrmOperationFactory.GetQuery(meta => meta.Plan.LongCount());
        }

        public long GetCount(Expression<Func<PlanEntity, bool>> expression)
        {
            return OrmOperationFactory.GetQuery(meta => meta.Plan.Where(expression).LongCount());
        }

        public IQueryable<PlanEntity> Get(long id)
        {
            return OrmOperationFactory.GetQuery(meta => meta.Plan.Where(p => p.Id == id));
        }

        public IQueryable<PlanEntity> GetAll()
        {
            return OrmOperationFactory.GetQuery(meta => meta.Plan);
        }

        public IQueryable<PlanEntity> Add(PlanEntity entity)
        {
            return OrmOperationFactory.DoCommand( adapter =>
            {
                var result = adapter.SaveEntity(entity, true); 
                IQueryable<PlanEntity> items = new List<PlanEntity> {entity}.AsQueryable();
                return items;
            });
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