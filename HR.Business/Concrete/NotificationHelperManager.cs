using HR.Business.Abstract;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Business.Concrete
{
    public class NotificationHelperManager : INotificationHelperService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IEmployeeService _employeeService;

        public NotificationHelperManager(INotificationRepository notificationRepository, IEmployeeService employeeService)
        {
            _notificationRepository = notificationRepository;
            _employeeService = employeeService;
        }

        public Notification AddNotification(Employee employee)
        {
            var result = new Notification
                (
                    id: 0,
                    title: "New employee : " + employee.Name + " " + employee.Surname,
                    notificationType: NotificationTypes.Recruitment,
                    userId: _employeeService.Get(employee.Id).UserId,
                    status: Status.Pending,
                    recordId : employee.Id
                );

            return _notificationRepository.Add(result);
        }

        public Notification AddNotification(DiseaseBulleten disease)
        {
            var employee = _employeeService.Get(disease.EmployeeId);

            var result = new Notification
                (
                    id: 0,
                    title: "New bulleten : " + employee.Name + " " + employee.Surname,
                    notificationType: NotificationTypes.Disease,
                    userId: _employeeService.Get(employee.Id).UserId,
                    status: Status.Pending,
                    recordId: disease.Id
                );

            return _notificationRepository.Add(result);
        }

        public Notification AddNotification(Permission permission)
        {
            var employee = _employeeService.Get(permission.EmployeeId);

            var result = new Notification
                (
                    id: 0,
                    title: "New permission request : " + employee.Name + " " + employee.Surname,
                    notificationType: NotificationTypes.Permission,
                    userId: _employeeService.Get(employee.Id).UserId,
                    status: Status.Pending,
                    recordId: permission.Id
                );

            return _notificationRepository.Add(result);
        }

        public Notification AddNotification(Vacation vacation)
        {
            var employee = _employeeService.Get(vacation.EmployeeId);

            var result = new Notification
                (
                    id: 0,
                    title: "New vacation request : " + employee.Name + " " + employee.Surname,
                    notificationType: NotificationTypes.Vacation,
                    userId: _employeeService.Get(employee.Id).UserId,
                    status: Status.Pending,
                    recordId: vacation.Id
                );

            return _notificationRepository.Add(result);
        }
    }
}
