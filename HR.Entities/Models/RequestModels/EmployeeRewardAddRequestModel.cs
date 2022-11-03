using Core.Entities.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class EmployeeRewardAddRequestModel : IAddModel
    {
        public int EmployeeId { get; set; }
        public int RewardId { get; set; }
        public DateTime Date { get; set; }

        public EmployeeRewardAddRequestModel()
        {

        }

        public EmployeeRewardAddRequestModel(int employeeId, int rewardId, DateTime date)
        {
            EmployeeId = employeeId;
            RewardId = rewardId;
            Date = date;
        }
    }
}
