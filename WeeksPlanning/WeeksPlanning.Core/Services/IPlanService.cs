using WeeksPlanning.Core.Core;

namespace WeeksPlanning.Core.Services
{
    public interface IPlanService : IService
    {
        string GetPlanName();
    }
}