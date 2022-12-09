using Core.Business.Abstract;
using Core.Entities.Concrete;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.RequestModels;

namespace HR.Business.Abstract
{
    public interface INotificationService : IExtendedServiceRepository<Notification>
    {
        Employee Recruitment(int notificationId);
        DiseaseBulleten Disease(int notificationId);
        Permission Permission(int notificationId);
        Vacation Vacation(int notificationId);
        NotificationTypes GetNotificationType(int notificationId);
        List<Notification> GetByUser(int userId);
        Notification SetStatus(int notificationId, Status status);
        Notification SaveEmployee(int notificationId, EmployeeUpdateRequestModel model);
    }
}
