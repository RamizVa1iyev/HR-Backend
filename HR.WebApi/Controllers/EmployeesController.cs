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
    public class EmployeesController : BaseController<IEmployeeService, Employee, EmployeeAddRequestModel, EmployeeUpdateRequestModel, EmployeeDeleteRequestModel>
    {
        public EmployeesController(IEmployeeService service) : base(service)
        {

        }

        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int userId)
        {
            return Ok(Service.GetEmployeeByUser(userId));
        }

        [HttpGet("getbyduty")]
        public IActionResult GetByDuty(int dutyId)
        {
            return Ok(Service.GetEmployeeByDuty(dutyId));
        }

        [HttpPost("changeworkstatus")]
        public IActionResult ChangeWorkStatus(EmployeeWorkStatusModel model)
        {
            return Ok(Service.ChangeWorkStatus(model.EmployeeId, model.Status));
        }

    }
}
