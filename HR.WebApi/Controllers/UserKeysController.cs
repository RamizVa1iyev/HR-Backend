using Core.Business.Abstract;
using Core.Entities.Models;
using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserKeysController : BaseController<IUserKeyService, UserKey, UserKeyAddRequestModel, UserKeyUpdateRequestModel, UserKeyDeleteRequestModel>
    {
        private readonly IAuthService _authService;
        public UserKeysController(IUserKeyService service, IAuthService authService) : base(service)
        {
            _authService = authService;
        }

        [HttpGet("generatekey")]
        public IActionResult GenerateKey(int roleId)
        {
            return Ok(Service.Generate(roleId));
        }

        [HttpPost("registerwithkey")]
        public IActionResult RegisterWithKey(UserForRegisterModel user)
        {
            var userToRegister = Service.RegisterWithKey(user);
            var accessToken = _authService.CreateAccessToken(userToRegister);
            var result = new UserRegisterResponseModel(userToRegister, accessToken);
            return Ok(result);
        }
    }
}
