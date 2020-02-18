using System;
using FluentValidation;
using Framework.Constants;
using WeeksPlanning.Core.Features.Plan.Models;

namespace WeeksPlanning.Core.Features.Plan.Validation
{
    public class NewPlanInputValidator : AbstractValidator<NewPlanInput>
    {
        public NewPlanInputValidator()
        {
            RuleFor(x => x.Id)
                .Null();
            
            RuleFor(x => x.Name)
                .NotNull()
                .Length(StringLength._2, StringLength._250);
            
            RuleFor(x => x.DurationInWeeks)
                .NotNull()
                .InclusiveBetween(StringLength._2, StringLength._50);
            
            RuleFor(x => x.StartingDateUtc)
                .NotNull()
                .GreaterThan(x => DateTime.Today
                    .Subtract(TimeSpan.FromDays(x.DurationInWeeks * Calender.DaysOfWeek)));
            
            RuleFor(x => x.CreatedByUserId)
                .NotNull();
        }   
    }
    
    
    public class UpdatePlanInputValidator : AbstractValidator<UpdatePlanInput>
    {
        public UpdatePlanInputValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
            
            RuleFor(x => x.Name)
                .Length(StringLength._2, StringLength._250)
                .When(x => x.Name != null);
            
            RuleFor(x => x.DurationInWeeks)
                .InclusiveBetween(StringLength._2, StringLength._50)
                .When(x => x.DurationInWeeks != null)
                .NotNull()
                .When(x => x.StartingDateUtc != null);

            RuleFor(x => x.StartingDateUtc)
                .GreaterThan(x => DateTime.Today
                    .Subtract(TimeSpan.FromDays(x.DurationInWeeks.GetValueOrDefault() * Calender.DaysOfWeek)));
        }   
    }
}