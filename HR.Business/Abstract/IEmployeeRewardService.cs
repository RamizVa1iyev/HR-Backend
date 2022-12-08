using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IEmployeeRewardService : IExtendedServiceRepository<EmployeeReward>
    {
        List<EmployeeReward> GetEmployeeRewardByEmployee(int employeeId);
        List<EmployeeReward> GetEmployeeRewardByReward(int rewardId);

    }
}
