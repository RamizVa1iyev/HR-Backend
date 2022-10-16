using FluentValidation;
using FluentValidation.Results;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class CalendarDayValidator : AbstractValidator<CalendarDay>
    {
        public CalendarDayValidator()
        {
            RuleFor(c => c.Date).GreaterThan(new DateTime());
            RuleFor(c => c.DayType).NotNull();
        }
    }
}