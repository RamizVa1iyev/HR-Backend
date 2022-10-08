using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class EmployeeReward : Entity
    {
        public int EmployeeId { get; set; }
        public int RewardId { get; set; }
        public DateTime Date { get; set; }

        public EmployeeReward()
        {

        }

        public EmployeeReward(int id, int employeeId, int rewardId, DateTime date) : base(id)
        {
            EmployeeId = employeeId;
            RewardId = rewardId;
            Date = date;
        }
    }
}
