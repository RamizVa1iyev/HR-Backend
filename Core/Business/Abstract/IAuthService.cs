using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.Features.Results.Abstract;
using Core.Features.Security.Jwt;

namespace Core.Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserForRegisterModel userForRegisterDto);
        User Login(UserForLoginModel userForLoginDto);
        void UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
