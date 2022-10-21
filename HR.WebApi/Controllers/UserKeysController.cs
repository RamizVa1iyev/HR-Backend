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
        public UserKeysController(IUserKeyService service) : base(service)
        {
        }

        [HttpGet("generatekey")]
        public IActionResult GenerateKey(int roleId)
        {
            return Ok(Service.Generate(roleId));
        }

        public IActionResult RegisterWithKey(UserForRegisterModel user)
        {
            return Ok(Service.RegisterWithKey(user));
        }
    }
}
