using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.WebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : BaseController<IUserService, User, TestAddRequest, testUpdate, testDelete>
    {
        private readonly IUserService _userService;

        public TestsController(IUserService service) : base(service)
        {
        }
    }
}
