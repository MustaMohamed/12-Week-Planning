using System;
using System.Collections.Generic;
using WeeksPlanning.Core.Repositories;
using WeeksPlanning.Entity.EntityClasses;
using WeeksPlanning.Test.Repositories.Mock;
using Xunit;

namespace WeeksPlanning.Test.Repositories
{
    public class PlanRepositoryTests
    {
        private readonly IPlanRepository _planRepository;

        public PlanRepositoryTests()
        {
            _planRepository = new FakePlanRepository(new List<PlanEntity>()
            {
                new PlanEntity()
                {
                    Id = 1,
                    Name = "First Plan",
                    StartingDateUtc = new DateTime(2020, 2, 15).ToUniversalTime(),
                    DurationInWeeks = 12,
                    IsActive = true,
                    DateCreatedUtc = new DateTime(2020, 2, 14).ToUniversalTime(),
                    CreatedByUserId = 1,
                    CreatedByUser = new UserEntity()
                    {
                        Id = 1,
                        Name = "Musta",
                        Email = "musta@azure.com",
                        IsActive = true,
                    }
                }
            });
        }

        [Fact]
        public void GetPlansCount_ReturnCount()
        {
            var allCount = _planRepository.GetCount();
            Assert.Equal(1, allCount);

            var activeCount = _planRepository.GetCount(p => p.IsActive == false);
            Assert.Equal(0, activeCount);

            var createdByUserCount = _planRepository.GetCount(p => p.CreatedByUserId == 1);
            Assert.Equal(1, createdByUserCount);
        }
    }
}