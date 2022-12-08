using Core.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Entities.Concrete
{
    public class Notification : Entity
    {
        public Notification()
        {

        }

        public Notification(int id, string title, NotificationTypes notificationType, int userId, Status status, int recordId)
        {
            Id = id;
            Title = title;
            NotificationType = notificationType;
            UserId = userId;
            Status = status;
            RecordId = recordId;
        }

        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public int UserId { get; set; }
        public Status Status { get; set; }
        public int RecordId { get; set; }
    }
}
