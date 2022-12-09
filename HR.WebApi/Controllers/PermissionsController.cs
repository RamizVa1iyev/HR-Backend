using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
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

        public override IActionResult Add(PermissionAddRequestModel entity)
        {
            var data = base.Map<PermissionAddRequestModel, Permission>(entity);
            switch (entity.PermissionType)
            {
                case PermissionTypes.Hour:
                    data.EndDate = entity.StartDate.AddHours(entity.Count);
                    break;
                case PermissionTypes.Day:
                    data.EndDate = entity.StartDate.AddDays(entity.Count);
                    break;
                default:
                    data.EndDate = data.StartDate;
                    break;
            }

            return Ok(Service.Add(data));
        }
    }
}
