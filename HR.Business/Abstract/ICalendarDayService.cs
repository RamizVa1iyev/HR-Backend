using Core.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Abstract
{
    public interface ICalendarDayService : IExtendedServiceRepository<CalendarDay>
    {
        CalendarDay Add(CalendarDayModel calendarDay);
    }
}
