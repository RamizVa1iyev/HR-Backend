using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class RewardManager : ManagerRepositoryBase<Reward, IRewardRepository>, IRewardService
    {
        public RewardManager(IRewardRepository repository) : base(repository)
        {
            base.SetValidator(new RewardValidator());
        }
    }
}
