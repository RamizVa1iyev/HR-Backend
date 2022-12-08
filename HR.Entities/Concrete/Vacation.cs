using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class Vacation : Entity
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VacationType { get; set; }
        public string Note { get; set; }

        //public Employee? Employee { get; set; }

        public Vacation()
        {

        }

        public Vacation(int id, int employeeId, DateTime startDate, DateTime endDate, int vacationType, string note) : base(id)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            VacationType = vacationType;
            Note = note;
        }
    }
}
