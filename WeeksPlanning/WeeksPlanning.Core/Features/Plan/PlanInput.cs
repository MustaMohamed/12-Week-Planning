using System;
using Framework.Interfaces;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Core.Features.Plan
{
    [Serializable]
    public class PlanInput : IToEntity<PlanEntity>
    {

        public long? Id { get; set; }
        public string PlanName { get; set; }
        public short PlanDurationInWeeks { get; set; }
        public DateTime? StatingDateUtc { get; set; }
        public long? CreatedByUserId { get; set; }
        public long? ModifiedByUserId { get; set; }

        public PlanEntity ToEntity()
        {
            if (Id == null)
            {
                return new PlanEntity()
                {
                    Name = PlanName,
                    DurationInWeeks = PlanDurationInWeeks,
                    StartingDateUtc = StatingDateUtc ?? DateTime.UtcNow,
                    DateCreatedUtc = DateTime.UtcNow,
                    CreatedByUserId = CreatedByUserId,
                };
            }
            return new PlanEntity()
            {
                Id = Id.GetValueOrDefault(),
                Name = PlanName,
                DurationInWeeks = PlanDurationInWeeks,
                StartingDateUtc = StatingDateUtc ?? DateTime.UtcNow,
                CreatedByUserId = CreatedByUserId,
                LastModifiedByUserId = ModifiedByUserId
            };
        }
    }
}