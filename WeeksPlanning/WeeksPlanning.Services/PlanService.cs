using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.DependencyInjection.Attributes;
using SD.LLBLGen.Pro.LinqSupportClasses;
using View.DtoClasses;
using View.Persistence;
using WeeksPlanning.Core.Features.Plan.Models;
using WeeksPlanning.Core.Repositories;
using WeeksPlanning.Core.Services;

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
            var items = result.Where(p => p.IsActive);
            var item = await items.ProjectToPlanView().FirstOrDefaultAsync();
            return item;
        }

        public async Task<PlanView> AddPlanAsync(NewPlanInput input)
        {
            var entity = input.ToEntity();
            var result = _planRepository.Add(entity);
            var planEntity = await result.ProjectToPlanView().FirstOrDefaultAsync();
            var item = planEntity;
            return item;
        }
    }
}