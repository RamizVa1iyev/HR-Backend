using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class NotificationUpdateRequestModel : IUpdateModel
    {
        public NotificationUpdateRequestModel()
        {

        }
        public NotificationUpdateRequestModel(int id, string title, NotificationTypes notificationType, int employeeId, bool used)
        {
            Id = id;
            Title = title;
            NotificationType = notificationType;
            EmployeeId = employeeId;
            Used = used;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public int EmployeeId { get; set; }
        public bool Used { get; set; }
    }
}
