using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class Overtime : Entity
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int HourCount { get; set; }
        public virtual Employee? Employee { get; set; }

        public Overtime()
        {

        }

        public Overtime(int id, int employeeId, DateTime date, int hourCount) : base(id)
        {
            EmployeeId = employeeId;
            Date = date;
            HourCount = hourCount;
        }
    }
}
