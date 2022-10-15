using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfUserSecretKeyRepository : EfRepositoryBase<UserKey, HRDBContext>, IUserKeyRepository
    {
        public EfUserSecretKeyRepository(HRDBContext context) : base(context)
        {
        }
    }
}
