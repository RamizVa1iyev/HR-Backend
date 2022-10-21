using Core.Entities.Concrete;
using FluentValidation;

namespace Core.Business.Validation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(u => u.UserId).NotNull();
            RuleFor(u => u.UserId).GreaterThan(0);
            RuleFor(u => u.OperationClaimId).NotNull();
            RuleFor(u => u.OperationClaimId).GreaterThan(0);
        }
    }
}
