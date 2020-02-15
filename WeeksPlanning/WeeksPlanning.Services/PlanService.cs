using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Config.Attributes;
using SD.LLBLGen.Pro.LinqSupportClasses;
using View.DtoClasses;
using View.Persistence;
using WeeksPlanning.Core.Repositories;
using WeeksPlanning.Core.Services;
using WeeksPlanning.Entity.EntityClasses;

namespace WeeksPlanning.Services
{
    [CreateInScope]
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<List<PlanView>> GetAllPlansAsync()
        {
            var result = _planRepository.GetAll();
            var items = await result
                .Where(p => p.IsActive)
                .ProjectToPlanView().ToListAsync();
            return items;
        }

        public async Task<PlanView> GetPlanByIdAsync(long planId)
        {
            var result = _planRepository.Get(planId);
            var items = await result.FirstOrDefaultAsync(p => p.IsActive);
            var item = items.ProjectToPlanView();
            return item;
        }

        public async Task<PlanView> AddPlanAsync(PlanEntity entity)
        {
            var result = _planRepository.Add(entity);
            var planEntity = await result.FirstOrDefaultAsync();
            var item = planEntity.ProjectToPlanView();
            return item;
        }
    }
}