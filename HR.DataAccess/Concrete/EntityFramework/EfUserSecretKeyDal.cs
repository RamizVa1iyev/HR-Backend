using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfUserSecretKeyDal : EfRepositoryBase<UserKey, HRDBContext>, IUserKeyDal
    {
        public EfUserSecretKeyDal(HRDBContext context) : base(context)
        {
        }
    }
}
