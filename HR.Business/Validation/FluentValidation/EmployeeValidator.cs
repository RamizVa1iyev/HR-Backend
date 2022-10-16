using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e=>e.Name).NotNull();
            RuleFor(e=>e.Surname).NotNull();
            RuleFor(e => e.FatherName).NotNull();
            RuleFor(e => e.FinCode).NotNull();
            RuleFor(e => e.FinCode).Length(7);
            RuleFor(e => e.Address).NotNull();
            RuleFor(e => e.Phone).NotNull();
            RuleFor(e => e.Gender).NotNull();
            RuleFor(e => e.BirthDay).GreaterThan(new DateTime());
            RuleFor(e => e.DailyWorkHour).GreaterThan(0);
            RuleFor(e => e.OperatingMode).NotNull();
            RuleFor(e => e.Status).NotNull();
            RuleFor(e => e.DutyId).GreaterThan(0);
            RuleFor(e => e.UserId).GreaterThan(0);

        }
    }
}