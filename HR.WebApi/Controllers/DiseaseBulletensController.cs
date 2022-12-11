using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseBulletensController : BaseController<IDiseaseBulletenService, DiseaseBulleten, DiseaseBulletenAddRequestModel, DiseaseBulletenUpdateRequestModel, DiseaseBulletenDeleteRequestModel>
    {
        public DiseaseBulletensController(IDiseaseBulletenService service) : base(service)
        {

        }

        [HttpGet("getbyemployee")]
        public IActionResult GetByEmployee(int employeeId)
        {
            return Ok(Service.GetDiseases(employeeId));
        }
    }
}
