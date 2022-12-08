using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class NotificationUpdateRequestModel : IUpdateModel
    {
        public NotificationUpdateRequestModel()
        {

        }
        public NotificationUpdateRequestModel(int id, string title, NotificationTypes notificationType, int userId, bool used)
        {
            Id = id;
            Title = title;
            NotificationType = notificationType;
            UserId = userId;
            Used = used;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public int UserId { get; set; }
        public bool Used { get; set; }
    }
}
