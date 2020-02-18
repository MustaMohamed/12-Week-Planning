using System.Collections.Generic;
using System.Threading.Tasks;
using View.DtoClasses;
using WeeksPlanning.Core.Core;
using WeeksPlanning.Core.Features.Plan.Models;

namespace WeeksPlanning.Core.Services
{
    public interface IPlanService : IService
    {
        Task<List<PlanView>> GetAllPlansAsync();
        
        Task<PlanView> GetPlanByIdAsync(int planId);

        Task<PlanView> AddPlanAsync(NewPlanInput entity);

        bool DeletePlan(int planId);
    }
}