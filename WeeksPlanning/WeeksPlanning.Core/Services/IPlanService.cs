using System.Collections.Generic;
using System.Threading.Tasks;
using View.DtoClasses;
using WeeksPlanning.Core.Core;

namespace WeeksPlanning.Core.Services
{
    public interface IPlanService : IService
    {
        Task<List<PlanView>> GetAllPlansAsync();
        
        Task<PlanView> GetPlanByIdAsync(long planId);
    }
}