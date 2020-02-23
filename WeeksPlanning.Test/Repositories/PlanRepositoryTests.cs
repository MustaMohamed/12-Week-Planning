using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void GetAllPlans_ReturnsAll()
        {
            var allPlans = _planRepository.GetAll();
            Assert.IsAssignableFrom<IQueryable<PlanEntity>>(allPlans);
            Assert.NotEmpty(allPlans);
        }

        [Fact]
        public void GetPlansById_ReturnsSingle()
        {
            var plan = _planRepository.Get(1);
            Assert.IsAssignableFrom<IQueryable<PlanEntity>>(plan);
            Assert.NotEmpty(plan);
            Assert.NotNull(plan.SingleOrDefault());
            Assert.True(plan.SingleOrDefault().IsActive);
        }

        [Fact]
        public void GetPlansById_ThrowException()
        {
            var plan = _planRepository.Get(2);
            Assert.Empty(plan);
            Assert.Null(plan.FirstOrDefault());
            Assert.Throws<NullReferenceException>(() => plan.FirstOrDefault().Id);
        }

        [Fact]
        public void AddNewPlan_SuccessfulAdd()
        {
            var newPlan = new PlanEntity()
            {
                Id = 2,
                Name = "Second Plan",
                DurationInWeeks = 4,
                StartingDateUtc = new DateTime(2020, 2, 22),
                IsActive = true,
            };
            var result = _planRepository.Add(newPlan);
            Assert.IsAssignableFrom<IQueryable<PlanEntity>>(result);
            Assert.NotEmpty(result);
            Assert.NotNull(result.SingleOrDefault());
            Assert.True(result.SingleOrDefault().IsActive);
            Assert.Equal(2, _planRepository.GetCount());
            Assert.NotEqual(1, _planRepository.GetCount());
        }

        [Fact]
        public void AddNewPlan_FailingToAdd()
        {
            var newPlan = new PlanEntity()
            {
                Id = 1,
                Name = "Second Plan",
                DurationInWeeks = 4,
                StartingDateUtc = new DateTime(2020, 2, 22),
                IsActive = false,
            };
            Assert.Throws<InvalidOperationException>(() => { _planRepository.Add(newPlan); });

            IQueryable<PlanEntity> result = new List<PlanEntity>().AsQueryable();
            try
            {
                result = _planRepository.Add(newPlan);
            }
            catch
            {
                Assert.IsAssignableFrom<IQueryable<PlanEntity>>(result);
                Assert.Empty(result);
                Assert.Null(result.SingleOrDefault());
                Assert.Equal(1, _planRepository.GetCount());
                Assert.NotEqual(2, _planRepository.GetCount());
            }
        }

        [Fact]
        public void UpdatePlan_SuccessfulUpdate()
        {
            var newPlan = new PlanEntity()
            {
                Id = 1,
                Name = "Updated Plan",
                DurationInWeeks = 4,
            };

            var result = _planRepository.Update(newPlan);
            Assert.IsAssignableFrom<IQueryable<PlanEntity>>(result);
            Assert.NotEmpty(result);

            var item = result.SingleOrDefault();

            Assert.NotNull(item);
            Assert.True(item.IsActive);
            Assert.Equal(1, _planRepository.GetCount());
            Assert.NotEqual(2, _planRepository.GetCount());

            Assert.True(item.Name.Equals("Updated Plan"));
            Assert.Equal(4, item.DurationInWeeks);
            Assert.NotEqual(new DateTime(2020, 2, 22), item.StartingDateUtc);
        }

        [Fact]
        public void UpdatePlan_FailingUpdate()
        {
            var updatePlan = new PlanEntity()
            {
                Id = 2,
                Name = "Updated Plan",
                DurationInWeeks = 4,
            };
            Assert.Throws<InvalidOperationException>(() => { _planRepository.Update(updatePlan); });
            IQueryable<PlanEntity> result = new List<PlanEntity>().AsQueryable();
            try
            {
                result = _planRepository.Update(updatePlan);
            }
            catch (Exception e)
            {
                Assert.IsAssignableFrom<IQueryable<PlanEntity>>(result);
                Assert.Empty(result);
                var item = result.SingleOrDefault();
                Assert.Null(item);
            }
        }
    }
}