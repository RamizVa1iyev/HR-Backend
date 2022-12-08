using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class EmployeeRewardManager : ManagerRepositoryBase<EmployeeReward, IEmployeeRewardRepository>, IEmployeeRewardService
    {
        public EmployeeRewardManager(IEmployeeRewardRepository repository) : base(repository)
        {
            base.SetValidator(new EmployeeRewardValidator());
        }

        public List<EmployeeReward> GetEmployeeRewardByEmployee(int employeeId)
        {
            return Repository.GetAll(e => e.EmployeeId == employeeId);
        }

        public List<EmployeeReward> GetEmployeeRewardByReward(int rewardId)
        {
            return Repository.GetAll(e => e.RewardId == rewardId);
        }
    }
}
