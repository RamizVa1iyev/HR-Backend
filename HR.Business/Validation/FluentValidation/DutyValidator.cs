using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class DutyValidator : AbstractValidator<Duty>
    {
        public DutyValidator()
        {
            RuleFor(d => d.Name).NotNull();
            RuleFor(d => d.Name).MinimumLength(3);
            RuleFor(d => d.StateId).NotNull();
            RuleFor(d => d.StateId).GreaterThan(0);
            RuleFor(d=>d.Salary).NotNull();
            RuleFor(d=>d.Salary).GreaterThan(0);
        }
    }
}
