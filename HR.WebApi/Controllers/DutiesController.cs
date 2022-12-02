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
    public class DutiesController : BaseController<IDutyService, Duty, DutyAddRequestModel, DutyUpdateRequestModel, DutyDeleteRequestModel>
    {
        public DutiesController(IDutyService service) : base(service)
        {
        }
    }
}
