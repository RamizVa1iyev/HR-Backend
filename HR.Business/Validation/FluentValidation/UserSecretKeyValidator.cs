﻿using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class UserSecretKeyValidator : AbstractValidator<UserSecretKey>
    {
        public UserSecretKeyValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SecretKey).NotNull();
            RuleFor(x => x.SecretKey).MinimumLength(5);
        }
    }
}
