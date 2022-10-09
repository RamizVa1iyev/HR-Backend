using Core.Business.Abstract;
using Core.Entities.Models;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.Other;
using HR.Entities.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarDaysController : ControllerBase
    {
        private readonly ICalendarDayService _calendarDayService;

        public CalendarDaysController(ICalendarDayService calendarDayService)
        {
            _calendarDayService = calendarDayService;
        }

        [HttpPost("add")]
        public IActionResult Add(CalendarDayModel calendarDay)        {
            
            var addedCalendarDay =  _calendarDayService.Add(calendarDay);
            var result = new CalendarDayResponseModel(addedCalendarDay);
            return Ok(result);
        }

    }
}
