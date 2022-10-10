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
    public class CalendarDaysController : BaseController<ICalendarDayService, CalendarDay, CalendarDayAddRequestModel, CalendarDayUpdateRequestModel, CalendarDayDeleteRequestModel>
    {
        //private readonly ICalendarDayService _calendarDayService;

        public CalendarDaysController(ICalendarDayService service) : base(service)
        {

        }


    }
}
