using Core.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Entities.Concrete
{
    public class CalendarDay : Entity
    {
        public DateTime Date { get; set; }
        public DayTypes DayType { get; set; }

        public CalendarDay()
        {

        }

        public CalendarDay(int id, DateTime date, DayTypes dayType) : base(id)
        {
            Date = date;
            DayType = dayType;
        }
    }
}
