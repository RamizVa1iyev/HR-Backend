using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfUserKeyRepository : EfRepositoryBase<UserKey, HRDBContext>, IUserKeyRepository
    {
        public EfUserKeyRepository(HRDBContext context) : base(context)
        {
        }

        public UserKey GetByKey(string key)
        {
            var result = from k in Context.UserKeys
                         where k.SecretKey == key & EF.Functions.DateDiffMinute(k.CreateDate, DateTime.Now) < 10 & !k.IsUsed
                         select k;
            return result.FirstOrDefault();
        }
    }
}
