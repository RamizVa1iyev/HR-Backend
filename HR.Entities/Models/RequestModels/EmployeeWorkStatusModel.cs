using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class EmployeeWorkStatusModel : IModel
    {
        public int EmployeeId { get; set; }
        public bool Status { get; set; }
    }
}
