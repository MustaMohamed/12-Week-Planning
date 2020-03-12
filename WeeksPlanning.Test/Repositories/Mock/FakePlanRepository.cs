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
            if (_plansList.Any(p => p.Id == entity.Id))
                throw new InvalidOperationException();
            _plansList.Add(entity);
            return _plansList.Where(p => p.Id == entity.Id).AsQueryable();
        }

        public IQueryable<PlanEntity> Update(PlanEntity entity)
        {
            var updateEntity = _plansList.FirstOrDefault(p => p.Id == entity.Id);
            if (updateEntity == null)
                throw new InvalidOperationException();
            ApplyUpdateEntity(ref updateEntity, entity);
            return _plansList.Where(p => p.Id == entity.Id).AsQueryable();
        }

        public bool Delete(PlanEntity entity)
        {
            return _plansList.Remove(entity);
        }

        public bool Delete(long id)
        {
            return _plansList.RemoveAll(p => p.Id == id) == 1;
        }

        private void ApplyUpdateEntity(ref PlanEntity dist, PlanEntity source)
        {
            if (source.Id > 0)
                dist.Id = source.Id;

            if (!string.IsNullOrEmpty(source.Name))
                dist.Name = source.Name;

            if (source.DurationInWeeks > 0)
                dist.DurationInWeeks = source.DurationInWeeks;

            if (source.StartingDateUtc.Year >= DateTime.Today.Year)
                dist.StartingDateUtc = source.StartingDateUtc;
        }
    }
}