using FluentValidation;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Validation.FluentValidation
{
    public class OvertimeValidator : AbstractValidator<Overtime>
    {
        public OvertimeValidator()
        {
            //RuleFor(o => o.EmployeeId).GreaterThan(0);
            //RuleFor(o => o.Date).GreaterThan(new DateTime());
            //RuleFor(o => o.HourCount).GreaterThan(0);

        }
    }
}
