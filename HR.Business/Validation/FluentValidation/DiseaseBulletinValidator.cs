using FluentValidation;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Validation.FluentValidation
{
    public class DiseaseBulletinValidator: AbstractValidator<DiseaseBulleten>
    {
        public DiseaseBulletinValidator()
        {
            RuleFor(c => c.EmployeeId).GreaterThan(0);
            RuleFor(c => c.DocumentNumber).NotNull();
            RuleFor(c => c.StartDate).GreaterThan(new DateTime());
            RuleFor(c => c.EndDate).GreaterThan(new DateTime());
            RuleFor(c => c.CreateDate).GreaterThan(new DateTime());
            RuleFor(c => c.PayPercent).GreaterThan(0);
        }
    }
}
