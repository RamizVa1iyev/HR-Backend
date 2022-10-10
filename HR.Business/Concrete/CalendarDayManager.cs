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
        protected CalendarDayManager(ICalendarDayRepository repository) : base(repository)
        {
           base.SetValidator(new CalendarDayValidator());
        }

      
    }
}
