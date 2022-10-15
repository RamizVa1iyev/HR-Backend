using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfCalendarDayDal : EfRepositoryBase<CalendarDay, HRDBContext>, ICalendarDayDal
    {
        public EfCalendarDayDal(HRDBContext context) : base(context)
        {
        }
    }
}
