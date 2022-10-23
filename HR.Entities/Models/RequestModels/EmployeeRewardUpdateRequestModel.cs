using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class EmployeeRewardUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RewardId { get; set; }
        public DateTime Date { get; set; }

        public EmployeeRewardUpdateRequestModel()
        {

        }

        public EmployeeRewardUpdateRequestModel(int employeeId, int rewardId, DateTime date)
        {
            EmployeeId = employeeId;
            RewardId = rewardId;
            Date = date;
        }
    }
}
