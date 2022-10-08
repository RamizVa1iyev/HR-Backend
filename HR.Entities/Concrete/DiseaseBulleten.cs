using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class DiseaseBulleten : Entity
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }

        public DiseaseBulleten()
        {

        }

        public DiseaseBulleten(int id, int employeeId, DateTime startDate, DateTime endDate, string note) : base(id)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
        }
    }
}
