using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WeeksPlanning.Core.Repositories;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Test.Repositories.Mock
{
    public class FakePlanRepository : IPlanRepository
    {
        private readonly List<PlanEntity> _plansList;

        public FakePlanRepository(List<PlanEntity> plansList)
        {
            _plansList = plansList;
        }

        public long GetCount()
        {
            return _plansList.Count;
        }

        public long GetCount(Expression<Func<PlanEntity, bool>> expression)
        {
            var excFunc = expression.Compile();
            return _plansList.Count(excFunc);
        }

        public IQueryable<PlanEntity> Get(int id)
        {
            return _plansList.Where(p => p.Id == id).AsQueryable();
        }

        public IQueryable<PlanEntity> GetAll()
        {
            return _plansList.AsQueryable();
        }

        public IQueryable<PlanEntity> Add(PlanEntity entity)
        {
            _plansList.Add(entity);
            return _plansList.Where(p => p.Id == entity.Id).AsQueryable();
        }

        public IQueryable<PlanEntity> Update(PlanEntity entity)
        {
            var updateEntity = _plansList.Find(p => p.Id == entity.Id);
            updateEntity = entity;
            return _plansList.Where(p => p.Id == entity.Id).AsQueryable();
        }

        public bool Delete(PlanEntity entity)
        {
            return _plansList.Remove(entity);
        }

        public bool Delete(int id)
        {
            return _plansList.RemoveAll(p => p.Id == id) == 1;
        }
    }
}