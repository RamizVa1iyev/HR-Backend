using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface ICalendarDayService : IExtendedServiceRepository<CalendarDay>
    {
        List<CalendarDay> GetByDate(DateTime date);
    }
}
