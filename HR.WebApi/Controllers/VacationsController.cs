using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : BaseController<IVacationServices, Vacation, VacationAddRequestModel, VacationUpdateRequestModel, VacationDeleteRequestModel>
    {
        public VacationsController(IVacationServices service) : base(service)
        {

        }
    }
}
