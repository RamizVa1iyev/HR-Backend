using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class CalendarDayAddRequestModel : IAddModel
    {
        public DateTime Date { get; set; }
        public DayTypes DayType { get; set; }

        public CalendarDayAddRequestModel()
        {

        }

        public CalendarDayAddRequestModel(DateTime date, DayTypes dayType)
        {
            Date = date;
            DayType = dayType;
        }
    }
}
