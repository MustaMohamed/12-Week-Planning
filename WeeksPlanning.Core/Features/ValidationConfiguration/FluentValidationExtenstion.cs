using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WeeksPlanning.Core.Features.Plan.Models;
using WeeksPlanning.Core.Features.Plan.Validation;

namespace WeeksPlanning.Core.Features.ValidationConfiguration
{
    public static class FluentValidationExtenstion
    {
        public static IServiceCollection AddApplicationValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NewPlanInput>, NewPlanInputValidator>();
            services.AddTransient<IValidator<UpdatePlanInput>, UpdatePlanInputValidator>();

            return services;
        }
    }
}