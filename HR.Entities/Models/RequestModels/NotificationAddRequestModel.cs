using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class NotificationAddRequestModel : IAddModel
    {
        public NotificationAddRequestModel()
        {

        }
        public NotificationAddRequestModel(string title, NotificationTypes notificationType, int userId, Status status)
        {
            Title = title;
            NotificationType = notificationType;
            UserId = userId;
            Status = status;
        }

        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public int UserId { get; set; }
        public Status Status { get; set; }
    }
}
