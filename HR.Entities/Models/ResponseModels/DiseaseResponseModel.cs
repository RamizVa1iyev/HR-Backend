using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.ResponseModels
{
    public class DiseaseResponseModel : IModel
    {
        public DiseaseResponseModel() { }
        public DiseaseResponseModel(int id, int employeeId, DateTime startDate, DateTime endDate, string note, string documentNumber, DateTime createDate, string clinicName, double payPercent, Status status)
        {
            Id = id;
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
            DocumentNumber = documentNumber;
            CreateDate = createDate;
            ClinicName = clinicName;
            PayPercent = payPercent;
            Status = status;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string ClinicName { get; set; }
        public double PayPercent { get; set; }
        public Status Status { get; set; }
    }
}
