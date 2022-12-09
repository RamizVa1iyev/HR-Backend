using Core.Entities.Concrete;
using System.Diagnostics;

namespace HR.Entities.Concrete
{
    public class DiseaseBulleten : Entity
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string ClinicName { get; set; }
        //public virtual Employee? Employee { get; set; }
        public double PayPercent { get; set; }

        public DiseaseBulleten()
        {

        }

        public DiseaseBulleten(int id, int employeeId, DateTime startDate, DateTime endDate, string note, string documentNumber, 
            DateTime createDate, string clinicName, double payPercent) : base(id)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
            DocumentNumber = documentNumber;
            CreateDate = createDate;
            ClinicName = clinicName;
            PayPercent = payPercent;
        }
    }
}
