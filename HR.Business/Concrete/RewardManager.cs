using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Concrete
{
    public class RewardManager : ManagerRepositoryBase<Reward, IRewardRepository>, IRewardService
    {
        public RewardManager(IRewardRepository repository) : base(repository)
        {
            base.SetValidator(new RewardValidator());
        }
    }

    public class EmployeeRewardManager : ManagerRepositoryBase<EmployeeReward, IEmployeeRewardRepository>, IEmployeeRewardService
    {
        public EmployeeRewardManager(IEmployeeRewardRepository repository) : base(repository)
        {
            base.SetValidator(new EmployeeRewardValidator());
        }
    }
}
