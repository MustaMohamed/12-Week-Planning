using DependencyInjection.Config.Attributes;
using WeeksPlanning.Core.Services;

namespace WeeksPlanning.Repositories
{
    [CreateSingleton]
    public class PlanService : IPlanService
    {
        public string GetPlanName()
        {
            return "Singleton Plan";
        }
    }
}