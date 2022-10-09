using Core.Entities.Models;
using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarDaysController : BaseController<ICalendarDayService, CalendarDay, TestAdd, TestUpdate, TestDelete>
    {
        private readonly ICalendarDayService _calendarDayService;

        public CalendarDaysController(ICalendarDayService service) : base(service)
        {
        }
    }
}
