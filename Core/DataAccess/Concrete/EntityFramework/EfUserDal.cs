using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework.Contexts;
using Core.DataAccess.Repositories.EntityFramework;
using Core.Entities.Concrete;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, CoreContext>, IUserDal
    {
        public EfUserDal(CoreContext context) : base(context)
        {

        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in Context.OperationClaims
                         join userOperationClaim in Context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();


            //return new List<OperationClaim>();
        }
    }
}
