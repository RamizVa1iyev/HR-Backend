using Core.Business.Concrete;
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
            var data = base.Add(entity);

            _notificationService.AddNotification(data);

            return data;
        }

        public List<PermissionResponseModel> GetPermissions(int employeeId)
        {
            return Repository.GetPermissions(p => p.EmployeeId == employeeId);
        }
    }
}
