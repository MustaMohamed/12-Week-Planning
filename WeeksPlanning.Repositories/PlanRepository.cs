using System;
using System.Linq;
using System.Linq.Expressions;
using Framework;
using Framework.DependencyInjection.Attributes;
using SD.LLBLGen.Pro.ORMSupportClasses;
using WeeksPlanning.Core.Repositories;
using WeeksPlanning.Entity.EntityClasses;
using WeeksPlanning.Entity.HelperClasses;

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

        public IQueryable<PlanEntity> Get(int id)
        {
            return OrmOperationFactory.GetQuery(meta => meta.Plan.Where(p => p.Id == id));
        }

        public IQueryable<PlanEntity> GetAll()
        {
            return OrmOperationFactory.GetQuery(meta => meta.Plan);
        }

        public IQueryable<PlanEntity> Add(PlanEntity entity)
        {
            return OrmOperationFactory.DoCommand((adapter, meta) =>
            {

                try
                {
                    var result = adapter.SaveEntity(entity, true);
                    if (result)
                    {
                        IQueryable<PlanEntity> items = meta.Plan.Where(p => p.Id == entity.Id);
                        return items;
                    }
                    throw new Exception("Can't save entity");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        public IQueryable<PlanEntity> Update(PlanEntity entity)
        {
            return OrmOperationFactory.DoCommand((adapter, meta) =>
            {

                try
                {
                    var result = adapter.SaveEntity(entity, true);
                    if (result)
                    {
                        IQueryable<PlanEntity> items = meta.Plan.Where(p => p.Id == entity.Id);
                        return items;
                    }
                    throw new Exception("Can't save entity");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        public bool Delete(PlanEntity entity)
        {
            return Delete(entity.Id);
        }

        public bool Delete(long id)
        {
            return OrmOperationFactory.DoCommand((adapter, meta) =>
            {

                try
                {
                    var isDeletedBefore = meta.Plan.FirstOrDefault(p => p.Id == id && !p.IsActive);
                    if (isDeletedBefore != null) return false;
                    var predicate = new RelationPredicateBucket(PlanFields.Id == id);
                    var changes = new PlanEntity()
                    {
                        IsActive = false
                    };
                    var result = adapter.UpdateEntitiesDirectly(changes, predicate);
                    return result > 0;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }
    }
}