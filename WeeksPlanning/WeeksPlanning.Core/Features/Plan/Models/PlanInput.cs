using System;
using Framework.Interfaces;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Core.Features.Plan.Models
{
    [Serializable]
    public class NewPlanInput : IToEntity<PlanEntity>
    {
        public long? Id { get; set; }
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
}