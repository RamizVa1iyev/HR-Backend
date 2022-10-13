using Core.Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Core.Business.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u=>u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
