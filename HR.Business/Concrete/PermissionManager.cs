using Core.Business.Concrete;
using Core.CCC.Exception;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Concrete
{
    public class PermissionManager : ManagerRepositoryBase<Permission, IPermissionRepository>, IPermissionService
    {
        private readonly INotificationHelperService _notificationService;
        public PermissionManager(IPermissionRepository repository, INotificationHelperService notificationService) : base(repository)
        {
            base.SetValidator(new PermissionValidator());
            _notificationService = notificationService;
        }

        public List<Permission> GetPermissionByEmployee(int employeeId)
        {
            return Repository.GetAll(p => p.EmployeeId == employeeId);
        }

        public override Permission Add(Permission entity)
        {
            CheckQuota(entity);
            var data = base.Add(entity);

            _notificationService.AddNotification(data);

            return data;
        }

        public override Permission Update(Permission entity)
        {
            CheckQuota(entity);
            return base.Update(entity);
        }

        public List<PermissionResponseModel> GetPermissions(int employeeId)
        {
            return Repository.GetPermissions(p => p.EmployeeId == employeeId);
        }

        private void CheckQuota(Permission entity)
        {
            var dayCount = Repository.GetDayCount(entity.EmployeeId);
            var hourCount = Repository.GetHourCount(entity.EmployeeId);

            if (dayCount + (int)(entity.EndDate - entity.StartDate).TotalDays > 2)
                throw new BusinessException("Quota exceeded. Max permission time is 2 day 5 hour. You have:" + dayCount + " day " + hourCount + " hour.");

            if(hourCount + (int)(entity.EndDate - entity.StartDate).TotalHours > 5)
                throw new BusinessException("Quota exceeded. Max permission time is 2 day 5 hour. You have:" + dayCount + " day " + hourCount + " hour.");
        }
    }
}
