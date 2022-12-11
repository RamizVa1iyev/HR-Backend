using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.ResponseModels
{
    public class VacationResponseModel : IModel
    {
        public VacationResponseModel() { }
        public VacationResponseModel(int id, int employeeId, DateTime startDate, DateTime endDate, int vacationType, string note, Status status)
        {
            Id = id;
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            VacationType = vacationType;
            Note = note;
            Status = status;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VacationType { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
    }
}
