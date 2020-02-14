using Microsoft.AspNetCore.Mvc;
using WeeksPlanning.Core.Services;

namespace WeekPlanning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPlanService _planService;

        public WeatherForecastController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public string Get()
        {
            return _planService.GetPlanName();
        }
    }
}