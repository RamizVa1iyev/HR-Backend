using Core.DataAccess.Repositories;
using Core.Entities.Concrete;

namespace Core.DataAccess.Abstract
{
    public interface IUserDal : IExtendedRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
