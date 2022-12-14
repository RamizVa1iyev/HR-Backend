using Core.Aspects.Autofac.Caching;
using Core.Business.Abstract;
using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.RequestModels;

namespace HR.Business.Concrete
{
    public class NotificationManager : ManagerRepositoryBase<Notification, INotificationRepository>, INotificationService
    {
        private readonly IDiseaseBulletenService _diseaseBulletenService;
        private readonly IPermissionService _permissionService;
        private readonly IEmployeeService _employeeService;
        private readonly IVacationService _vacationService;

        public NotificationManager(INotificationRepository repository, IDiseaseBulletenService diseaseBulletenService, IPermissionService permissionService, IEmployeeService employeeService, IVacationService vacationService) : base(repository)
        {
            base.SetValidator(new NotificationValidator());
            _diseaseBulletenService = diseaseBulletenService;
            _permissionService = permissionService;
            _employeeService = employeeService;
            _vacationService = vacationService;
        }

        public override List<Notification> GetAll()
        {
            return Repository.GetAll(n => n.Status == Status.Pending);
        }

        [CacheAspect]
        public DiseaseBulleten Disease(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _diseaseBulletenService.Get(notification.RecordId);

            return data;
        }

        [CacheAspect]
        public List<Notification> GetByUser(int userId)
        {
            return Repository.GetAll(n => n.UserId == userId & n.Status == Status.Pending);
        }

        [CacheAspect]
        public NotificationTypes GetNotificationType(int notificationId)
        {
            return Repository.Get(n => n.Id == notificationId).NotificationType;
        }

        [CacheAspect]
        public Permission Permission(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _permissionService.Get(notification.RecordId);

            return data;
        }

        [CacheAspect]
        public Employee Recruitment(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _employeeService.Get(notification.RecordId);

            return data;
        }

        [CacheAspect]
        public Vacation Vacation(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _vacationService.Get(notification.RecordId);

            return data;
        }

        [CacheRemoveAspect("get")]
        public Notification SetStatus(int notificationId, Status status)
        {
            var notification = base.Get(notificationId);
            notification.Status = status;

            return Repository.Update(notification);
        }

        [CacheRemoveAspect("get")]
        public Notification SaveEmployee(int notificationId, EmployeeUpdateRequestModel model)
        {
            var notification = base.Get(notificationId);
            notification.Status = model.Status;

            var employee = base.Map<EmployeeUpdateRequestModel, Employee>(model);
            _employeeService.Update(employee);

            return Repository.Update(notification);
        }
    }
}
