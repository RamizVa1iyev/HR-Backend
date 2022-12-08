using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class VacationAddRequestModel : IAddModel
    {
        public VacationAddRequestModel()
        {

        }

        public VacationAddRequestModel(int employeeId, DateTime startDate, DateTime endDate, int vacationType, string note)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            VacationType = vacationType;
            Note = note;
        }

        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VacationType { get; set; }
        public string Note { get; set; }
    }
}
