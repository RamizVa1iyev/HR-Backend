using Core.Entities.Abstract;
using HR.Entities.Concrete;

namespace HR.Entities.Models.RequestModels
{
    public class DiseaseBulletenUpdateRequestModel : IUpdateModel
    {
        public DiseaseBulletenUpdateRequestModel()
        {

        }

        public DiseaseBulletenUpdateRequestModel(int id, int employeeId, DateTime startDate, DateTime endDate, string note, string documentNumber, string clinicName, double payPercent)
        {
            Id = id;
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
            DocumentNumber = documentNumber;
            //CreateDate = createDate;
            ClinicName = clinicName;
            PayPercent = payPercent;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public string DocumentNumber { get; set; }
        //public DateTime CreateDate { get; set; }
        public string ClinicName { get; set; }
        public double PayPercent { get; set; }

    }
}
