using FluentValidation;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Validation.FluentValidation
{
    public class RewardValidator : AbstractValidator<Reward>
    {
        public RewardValidator()
        {

        }
    }
}
