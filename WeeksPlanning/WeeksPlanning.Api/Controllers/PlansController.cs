using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using View.DtoClasses;
using WeeksPlanning.Core.Features.Plan.Models;
using WeeksPlanning.Core.Services;

namespace WeekPlanning.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlansController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IValidator<NewPlanInput> _newPlanInputValidator;

        public PlansController(IPlanService planService, IValidator<NewPlanInput> newPlanInputValidator)
        {
            _planService = planService;
            _newPlanInputValidator = newPlanInputValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanView>>> Plans()
        {
            try
            {
                var result = await _planService.GetAllPlansAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PlanView>> Plan(int id)
        {
            try
            {
                var result = await _planService.GetPlanByIdAsync(id);
            
                if (result == null)
                    return NotFound();
            
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PlanView>> Add([FromBody] NewPlanInput newPlanInput)
        {
            try
            {
                var validationResult = _newPlanInputValidator.Validate(newPlanInput);
                if (validationResult.IsValid)
                {
                    var result = await _planService.AddPlanAsync(newPlanInput);
                    return result;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}