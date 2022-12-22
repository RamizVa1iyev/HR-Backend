using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfUserKeyRepository : EfRepositoryBase<UserKey, HRDBContext>, IUserKeyRepository
    {
        public EfUserKeyRepository(HRDBContext context) : base(context)
        {
        }

        public UserKey GetByKey(string key)
        {
            // Minute count was modified 22.12.22 because of testing time. This must be corrected in production time.
            var result = from k in Context.UserKeys
                         where k.SecretKey == key & EF.Functions.DateDiffMinute(k.CreateDate, DateTime.Now) < 7200 & !k.IsUsed
                         select k;
            return result?.FirstOrDefault();
        }
    }
}
