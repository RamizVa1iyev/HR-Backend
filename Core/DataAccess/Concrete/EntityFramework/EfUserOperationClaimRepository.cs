using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework.Contexts;
using Core.DataAccess.Repositories.EntityFramework;
using Core.Entities.Concrete;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, CoreContext>, IUserOperationClaimRepository
    {
        public EfUserOperationClaimRepository(CoreContext context) : base(context)
        {
        }
    }
}
