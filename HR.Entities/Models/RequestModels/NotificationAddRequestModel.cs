using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class NotificationAddRequestModel : IAddModel
    {
        public NotificationAddRequestModel()
        {

        }
        public NotificationAddRequestModel(string title, NotificationTypes notificationType, int userId, bool used)
        {
            Title = title;
            NotificationType = notificationType;
            UserId = userId;
            Used = used;
        }

        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public int UserId { get; set; }
        public bool Used { get; set; }
    }
}
