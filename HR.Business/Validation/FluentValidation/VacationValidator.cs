using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class VacationValidator: AbstractValidator<Vacation>
    {
        public VacationValidator()
        {
            RuleFor(c => c.EmployeeId).GreaterThan(0);
            RuleFor(c => c.StartDate).GreaterThan(new DateTime());
            RuleFor(c => c.EndDate).GreaterThan(new DateTime());
        }
    }
}
