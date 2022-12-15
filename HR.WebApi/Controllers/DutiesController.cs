using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.RequestModels;
using HR.Entities.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutiesController : BaseController<IDutyService, Duty, DutyAddRequestModel, DutyUpdateRequestModel, DutyDeleteRequestModel>
    {
        private readonly IStateService _stateService;
        public DutiesController(IDutyService service, IStateService stateService) : base(service)
        {
            _stateService = stateService;
        }

        [HttpGet("getAllStatesDuties")]
        public IActionResult GetAllStatesDuties()
        {
            var model = new DutyStateModel
            {
                Duties = Service.GetAll(),
                States = _stateService.GetAll()
            };

            return Ok(model);
        }
    }
}
