using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class UserKeyUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SecretKey { get; set; }

        public UserKeyUpdateRequestModel()
        {

        }

        public UserKeyUpdateRequestModel(int id, int userId, string secretKey)
        {
            Id = id;
            UserId = userId;
            SecretKey = secretKey;
        }
    }
}
