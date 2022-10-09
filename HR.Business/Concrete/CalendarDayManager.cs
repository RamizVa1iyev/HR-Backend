using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Concrete
{
    public class CalendarDayManager : ManagerRepositoryBase<CalendarDay, ICalendarDayRepository>, ICalendarDayService
    {
        private readonly ICalendarDayRepository _calendarDayRepository;
        protected CalendarDayManager(ICalendarDayRepository repository) : base(repository)
        {
            _calendarDayRepository = repository;
            base.SetValidator(new CalendarDayValidator());
        }

        public CalendarDay Add(CalendarDayModel calendarDayModel)
        {
            var calendarDay = new CalendarDay() { Date = calendarDayModel.Date, DayType = calendarDayModel.DayType };
            _calendarDayRepository.Add(calendarDay);
            return calendarDay;
        }
    }
}
