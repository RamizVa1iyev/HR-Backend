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

        public List<CalendarDay> GetByDate(DateTime date)
        {
            var first = new DateTime(date.Year, date.Month, 1);
            var last = first.AddMonths(1);

            return Repository.GetAll(c => c.Date >= first & c.Date < last);
        }
    }
}
