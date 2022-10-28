using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace Core.Business.Concrete
{
    public class OperationClaimManager : ManagerRepositoryBase<OperationClaim, IOperationClaimRepository>, IOperationClaimService
    {
        public OperationClaimManager(IOperationClaimRepository repository) : base(repository)
        {
        }
    }
}
