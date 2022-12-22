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
            return Ok(Service.GetPermissions(employeeId));
        }

        public override IActionResult Add(PermissionAddRequestModel entity)
        {
            var data = base.Map<PermissionAddRequestModel, Permission>(entity);
            data.EndDate = entity.PermissionType switch
            {
                PermissionTypes.Hour => entity.StartDate.AddHours(entity.Count),
                PermissionTypes.Day => entity.StartDate.AddDays(entity.Count)
            };
            return Ok(Service.Add(data));
        }

        public override IActionResult Update(PermissionUpdateRequestModel entity)
        {
            var data = base.Map<PermissionUpdateRequestModel, Permission>(entity);
            data.EndDate = entity.PermissionType switch
            {
                PermissionTypes.Hour => entity.StartDate.AddHours(entity.Count),
                PermissionTypes.Day => entity.StartDate.AddDays(entity.Count)
            };

            return Ok(Service.Update(data));
        }
    }
}
