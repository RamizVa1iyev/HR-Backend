using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class ContractValidator: AbstractValidator<Contract>
    {
        public ContractValidator()
        {
            RuleFor(c=>c.ContractEndDate).NotEmpty();
            RuleFor(c=>c.ContractStartDate).NotEmpty();
            RuleFor(c=>c.EmployeeId).GreaterThan(0);
            RuleFor(c=>c.ContractNumber).MinimumLength(5);
        }
    }
}
