using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Features.Security.Jwt;

namespace Core.Entities.Models
{
    public class UserLoginResponseModel:IModel
    {
        public UserLoginResponseModel()
        {

        }
        public UserLoginResponseModel(User? loggedUser, AccessToken accessToken)
        {
            LoggedUser = loggedUser;
            AccessToken = accessToken;
        }
        public User? LoggedUser { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
