using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class StateValidator : AbstractValidator<State>
    {
        public StateValidator()
        {
            RuleFor(s => s.Name).NotNull();
            RuleFor(s => s.Name).MinimumLength(2);
        }
    }
}
