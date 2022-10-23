using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class PermissionValidator : AbstractValidator<Permission>
    {
        public PermissionValidator()
        {
            
        }
    }
}