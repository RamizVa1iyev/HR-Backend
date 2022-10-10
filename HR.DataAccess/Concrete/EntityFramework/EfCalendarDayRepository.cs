using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfCalendarDayRepository : EfRepositoryBase<CalendarDay, HRDBContext>, ICalendarDayRepository
    {
        public EfCalendarDayRepository(HRDBContext context) : base(context)
        {
        }
    }
}
