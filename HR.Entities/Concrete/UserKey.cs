using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class UserKey : Entity
    {
        public int UserId { get; set; }
        public string SecretKey { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsUsed { get; set; }

        public UserKey()
        {

        }

        public UserKey(int id, int userId, string secretKey, DateTime createDate, bool isUsed) : base(id)
        {
            UserId = userId;
            SecretKey = secretKey;
            CreateDate = createDate;
            IsUsed = isUsed;
        }
    }
}
