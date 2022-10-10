using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class CalendarDayManager : ManagerRepositoryBase<CalendarDay, ICalendarDayRepository>, ICalendarDayService
    {
        public CalendarDayManager(ICalendarDayRepository repository) : base(repository)
        {
            base.SetValidator(new CalendarDayValidator());
        }


    }
}
