using Core.DataAccess.Repositories;
using HR.Entities.Concrete;

namespace HR.DataAccess.Abstract
{
    public interface IUserKeyRepository : IExtendedRepository<UserKey>
    {
        UserKey GetByKey(string key);
    }
}
