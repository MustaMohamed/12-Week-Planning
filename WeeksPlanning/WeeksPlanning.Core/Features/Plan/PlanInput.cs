using System;
using Framework.Interfaces;
using WeeksPlanning.Entity;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Core.Features.Plan
{
    [Serializable]
    public class PlanInput : IToEntity<PlanEntity>
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public short? DurationInWeeks { get; set; }
        public DateTime? StartingDateUtc { get; set; }
        public long? CreatedByUserId { get; set; }
        public long? LastModifiedByUserId { get; set; }

        public PlanEntity ToEntity()
        {
            var entity = new PlanEntity();

            if (Id != null)
            {
                entity.Id = Id.GetValueOrDefault();
                entity.IsNew = false;
            }

            if (!string.IsNullOrEmpty(Name))
                entity.Name = Name;
            
            if (DurationInWeeks != null)
                entity.DurationInWeeks = DurationInWeeks.GetValueOrDefault();
            
            if (StartingDateUtc != null)
                entity.StartingDateUtc = StartingDateUtc.GetValueOrDefault();

            if (CreatedByUserId != null)
            {
                entity.CreatedByUserId = CreatedByUserId.GetValueOrDefault();
                entity.DateCreatedUtc = DateTime.UtcNow;
            }

            if (LastModifiedByUserId != null)
            {
                entity.LastModifiedByUserId = LastModifiedByUserId.GetValueOrDefault();
                entity.LastModifiedUtc = DateTime.UtcNow;
            }

            return entity;
        }
    }
}