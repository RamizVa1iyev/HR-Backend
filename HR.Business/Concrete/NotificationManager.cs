using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Business.Concrete
{
    public class NotificationManager : ManagerRepositoryBase<Notification, INotificationRepository>, INotificationService
    {
        private readonly IDiseaseBulletenService _diseaseBulletenService;
        private readonly IOvertimeService _overtimeService;
        private readonly IPermissionService _permissionService;
        private readonly IEmployeeService _employeeService;
        private readonly IVacationService _vacationService;

        public NotificationManager(INotificationRepository repository, IDiseaseBulletenService diseaseBulletenService, IOvertimeService overtimeService, IPermissionService permissionService, IEmployeeService employeeService, IVacationService vacationService) : base(repository)
        {
            base.SetValidator(new NotificationValidator());
            _diseaseBulletenService = diseaseBulletenService;
            _overtimeService = overtimeService;
            _permissionService = permissionService;
            _employeeService = employeeService;
            _vacationService = vacationService;
        }

        public DiseaseBulleten Disease(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _diseaseBulletenService.Get(notification.RecordId);

            return data;
        }

        public List<Notification> GetByUser(int userId)
        {
            return Repository.GetAll(n => n.UserId == userId);
        }

        public NotificationTypes GetNotificationType(int notificationId)
        {
            return Repository.Get(n => n.Id == notificationId).NotificationType;
        }

        public Permission Permission(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _permissionService.Get(notification.RecordId);

            return data;
        }

        public Employee Recruitment(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _employeeService.Get(notification.RecordId);

            return data;
        }

        public Vacation Vacation(int notificationId)
        {
            var notification = Repository.Get(n => n.Id == notificationId);
            var data = _vacationService.Get(notification.RecordId);

            return data;
        }
    }
}
