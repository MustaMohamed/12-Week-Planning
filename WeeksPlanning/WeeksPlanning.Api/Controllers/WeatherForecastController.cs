using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ORM;
using SD.LLBLGen.Pro.LinqSupportClasses;
using WeeksPlanning.Core.Services;

namespace WeekPlanning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IPlanService _planService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPlanService planService)
        {
            _logger = logger;
            _planService = planService;
        }

        [HttpGet]
        public string Get()
        {
            return _planService.GetPlanName();
        }

    }
}