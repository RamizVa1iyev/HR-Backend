using Core.Entities.Concrete;
using Core.Features.Security.Jwt;

namespace Core.Entities.Models
{
    public class UserRegisterResponseModel
    {
        public UserRegisterResponseModel()
        {

        }
        public UserRegisterResponseModel(User? loggedUser, AccessToken accessToken)
        {
            RegisteredUser = loggedUser;
            AccessToken = accessToken;
        }
        public User? RegisteredUser { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
