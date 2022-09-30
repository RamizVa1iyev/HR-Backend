using Core.DataAccess.Repositories;
using Core.Entities.Concrete;

namespace Core.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
