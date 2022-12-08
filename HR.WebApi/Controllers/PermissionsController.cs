using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : BaseController<IPermissionService, Permission, PermissionAddRequestModel, PermissionUpdateRequestModel, PermissionDeleteRequestModel>
    {
        public PermissionsController(IPermissionService service) : base(service)
        {
        }

        [HttpGet("getbyemployee")]
        public IActionResult GetByEmployee(int employeeId)
        {
            return Ok(Service.GetPermissionByEmployee(employeeId));
        }
    }
}
