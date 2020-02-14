using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Config.Attributes;
using SD.LLBLGen.Pro.LinqSupportClasses;
using View.DtoClasses;
using View.Persistence;
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
            var items = result.ProjectToPlanView();
            var item = await items.FirstOrDefaultAsync(p => p.IsActive);
            return item;
        }
    }
}