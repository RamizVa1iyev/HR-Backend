using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserUpdatePasswordRequestModel : IModel
    {
        public UserUpdatePasswordRequestModel(int userId, string password)
        {
            UserId = userId;
            Password = password;
        }

        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
