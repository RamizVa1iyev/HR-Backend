using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface INotificationHelperService
    {
        Notification AddNotification(Employee employee);
        Notification AddNotification(DiseaseBulleten disease);
        Notification AddNotification(Permission permission);
        Notification AddNotification(Vacation vacation);
    }
}
