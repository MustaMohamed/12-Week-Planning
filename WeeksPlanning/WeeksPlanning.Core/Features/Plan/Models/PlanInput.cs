using System;
using Framework.Interfaces;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Core.Features.Plan.Models
{
    [Serializable]
    public class NewPlanInput : IToEntity<PlanEntity>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public short DurationInWeeks { get; set; }
        public DateTime StartingDateUtc { get; set; }
        public long? CreatedByUserId { get; set; }

        public PlanEntity ToEntity()
        {
            var entity = new PlanEntity()
            {
                Name = Name,
                DurationInWeeks = DurationInWeeks,
                StartingDateUtc = StartingDateUtc,
                DateCreatedUtc = DateTime.UtcNow,
                CreatedByUserId = CreatedByUserId,
            };
            return entity;
        }
    }
    
    public class UpdatePlanInput : IToEntity<PlanEntity>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public short? DurationInWeeks { get; set; }
        public DateTime? StartingDateUtc { get; set; }

        public PlanEntity ToEntity()
        {
            var entity = new PlanEntity()
            {
                IsNew = false
            };
            
            if (Id != null)
                entity.Id = Id.GetValueOrDefault();
            
            if (!string.IsNullOrEmpty(Name))
                entity.Name = Name;

            if (DurationInWeeks != null)
                entity.DurationInWeeks = DurationInWeeks.GetValueOrDefault();
            
            if (StartingDateUtc != null)
                entity.StartingDateUtc = StartingDateUtc.GetValueOrDefault();
            
            return entity;
        }
    }
}