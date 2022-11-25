﻿using FluentValidation;
using HR.Entities.Concrete;

namespace HR.Business.Validation.FluentValidation
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(n => n.Title).NotNull();
            RuleFor(n => n.Title).MinimumLength(3);
            RuleFor(n => n.EmployeeId).NotNull();
            RuleFor(n => n.EmployeeId).GreaterThanOrEqualTo(0);
            RuleFor(n => n.NotificationType).NotNull();
        }
    }
}
