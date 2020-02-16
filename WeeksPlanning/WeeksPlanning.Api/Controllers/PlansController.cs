using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using View.DtoClasses;
using WeeksPlanning.Core.Features.Plan;
using WeeksPlanning.Core.Services;

namespace WeekPlanning.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlansController : Controller
    {
        private readonly IPlanService _planService;

        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public async Task<List<PlanView>> Plans()
        {
            var result = await _planService.GetAllPlansAsync();
            return result;
        }

        [HttpGet]
        public async Task<PlanView> Plan()
        {
            var id = Convert.ToInt64("1");
            var result = await _planService.GetPlanByIdAsync(id);
            return result;
        }
        
        [HttpPost]
        public async Task<PlanView> Add([FromBody]PlanInput planInput)
        {
            var result = await _planService.AddPlanAsync(planInput);
            return result;
        }
    }
}