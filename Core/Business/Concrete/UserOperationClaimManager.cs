using Core.Business.Abstract;
using Core.Business.Validation;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace Core.Business.Concrete
{
    public class UserOperationClaimManager : ManagerRepositoryBase<UserOperationClaim, IUserOperationClaimRepository>, IUserOperationClaimService
    {
        public UserOperationClaimManager(IUserOperationClaimRepository repository) : base(repository)
        {
            base.SetValidator(new UserOperationClaimValidator());
        }
    }
}
