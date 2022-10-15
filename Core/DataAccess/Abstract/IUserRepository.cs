using Core.DataAccess.Repositories;
using Core.Entities.Concrete;

namespace Core.DataAccess.Abstract
{
    public interface IUserRepository : IExtendedRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
