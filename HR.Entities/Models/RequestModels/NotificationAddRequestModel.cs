using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class NotificationAddRequestModel : IAddModel
    {
        public NotificationAddRequestModel()
        {

        }
        public NotificationAddRequestModel(string title, NotificationTypes notificationType, int employeeId, bool used)
        {
            Title = title;
            NotificationType = notificationType;
            EmployeeId = employeeId;
            Used = used;
        }

        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public int EmployeeId { get; set; }
        public bool Used { get; set; }
    }
}
