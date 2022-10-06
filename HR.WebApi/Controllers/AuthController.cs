using Core.Business.Abstract;
using Core.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginModel userForLoginModel)
        {
            var userToLogin = _authService.Login(userForLoginModel);
            var accessToken = _authService.CreateAccessToken(userToLogin);

            var result = new UserLoginResponseModel(userToLogin,accessToken);
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterModel userForRegisterModel)
        {
            var userToRegister = _authService.Register(userForRegisterModel);
            var accessToken = _authService.CreateAccessToken(userToRegister);
            var result = new UserRegisterResponseModel(userToRegister, accessToken);
            return Ok(result);
        }
    }
}
// Asim 14/55
//Ramiz 14/58
//Afet 15/01
//Arzu 