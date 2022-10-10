using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class CalendarDayUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DayTypes DayType { get; set; }

        public CalendarDayUpdateRequestModel()
        {

        }

        public CalendarDayUpdateRequestModel(int id, DateTime date, DayTypes dayType) 
        {
            Date = date;
            DayType = dayType;
        }
    }
}
