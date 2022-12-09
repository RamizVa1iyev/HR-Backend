using Core.Entities.Abstract;
using HR.Entities.Concrete;

namespace HR.Entities.Models.RequestModels
{
    public class DiseaseBulletenAddRequestModel : IAddModel
    {
        public DiseaseBulletenAddRequestModel()
        {

        }

        public DiseaseBulletenAddRequestModel(int employeeId, DateTime startDate, DateTime endDate, string note, string documentNumber, DateTime createDate, string clinicName, double payPercent)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
            DocumentNumber = documentNumber;
            //CreateDate = createDate;
            ClinicName = clinicName;
            PayPercent = payPercent;
        }

        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public string DocumentNumber { get; set; }
       // public DateTime CreateDate { get; set; }=DateTime.Now;
        public string ClinicName { get; set; }
        public double PayPercent { get; set; }
    }
}
