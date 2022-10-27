using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthController(IAuthService authService, IUserService userService, IUserOperationClaimService userOperationClaimService)
        {
            _authService = authService;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
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

        [HttpPost("registercheck")]
        public IActionResult RegisterCheck(UserForRegisterCheckRequestModel user)
        {
            return Ok(_authService.RegisterCheck(user));
        }

        [HttpGet("getroles")]
        public IActionResult GetRoles(int userId)
        {
            return Ok(_userService.GetClaims(new User { Id = userId }));
        }

        [HttpGet("getallroles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_userOperationClaimService.GetAll());
        }
    }
}