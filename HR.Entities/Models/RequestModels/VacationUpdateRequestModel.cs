using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class VacationUpdateRequestModel : IUpdateModel
    {
        public VacationUpdateRequestModel()
        {

        }

        public VacationUpdateRequestModel(int id, int employeeId, DateTime startDate, DateTime endDate, int vacationType, string note)
        {
            Id = id;
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            VacationType = vacationType;
            Note = note;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VacationType { get; set; }
        public string Note { get; set; }
    }
}
