using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class CalendarDayDeleteRequestModel : IDeleteModel
    {
        public int Id { get; set; }
    }
}
