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
    [Route("api/[controller]")]
    public class PlansController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IValidator<NewPlanInput> _newPlanInputValidator;
        private readonly IValidator<UpdatePlanInput> _updatePlanInputValidator;

        public PlansController(IPlanService planService, IValidator<NewPlanInput> newPlanInputValidator, IValidator<UpdatePlanInput> updatePlanInputValidator)
        {
            _planService = planService;
            _newPlanInputValidator = newPlanInputValidator;
            _updatePlanInputValidator = updatePlanInputValidator;
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
        [Route("Create")]
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

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<PlanView>> Add([FromBody] UpdatePlanInput updatePlanInput, int id)
        {
            try
            {
                var validationResult = _updatePlanInputValidator.Validate(updatePlanInput);
                if (validationResult.IsValid)
                {
                    var result = await _planService.UpdatePlanAsync(updatePlanInput);
                    return result;
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Remove(int id)
        {
            try
            {
                var result = _planService.DeletePlan(id);
            
                if (!result)
                    return StatusCode(StatusCodes.Status404NotFound);
            
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}