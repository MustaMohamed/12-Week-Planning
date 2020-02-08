using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ORM;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace WeekPlanning.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Plan>> Get()
        {
            var items = await Query.GetAsync(async metaData =>
            {
                var plans = await metaData.Plan.ToListAsync();
                return plans.ConvertAll(x => new Plan() {Id = x.Id, Name = x.Name}).AsEnumerable();
            });
            return items;
        }

        public class Plan
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}