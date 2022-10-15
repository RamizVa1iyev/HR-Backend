using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class Vacation : Entity
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ComeWorkTime { get; set; }

        public Vacation()
        {

        }

        public Vacation(int id, int employeeId, DateTime startDate, DateTime endDate, DateTime comeWorkTime) : base(id)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            ComeWorkTime = comeWorkTime;
        }
    }
}
