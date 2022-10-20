using Core.Business.Abstract;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.Features.Results.Abstract;
using Core.Features.Security.Hashing;
using Core.Features.Security.Jwt;
using Core.Features.Results.Concrete;
using Core.CCC.Exception;
using Core.CrossCuttingConcerns.Validation;
using Core.Business.Validation;

namespace Core.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public User Register(UserForRegisterModel userForRegister)
        {
            UserExists(userForRegister.Email);
            HashingHelper.CreatePasswordHash(userForRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return user;
        }

        public User Login(UserForLoginModel userForLogin)
        {
            var userToCheck = _userService.GetByMail(userForLogin.Email);
            if (userToCheck == null)
            {
                throw new AuthorizationException(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new AuthorizationException(Messages.PasswordError);
            }

            return userToCheck;
        }

        public bool RegisterCheck(UserForRegisterModel userForRegister)
        {
            var result = true;

            try
            {
                UserExists(userForRegister.Email);
                HashingHelper.CreatePasswordHash(userForRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new User
                {
                    Email = userForRegister.Email,
                    FirstName = userForRegister.FirstName,
                    LastName = userForRegister.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                ValidationTool.Validate(new UserValidator(), user);

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public void UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                throw new BusinessException(Messages.UserAlreadyExists);
            }
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
