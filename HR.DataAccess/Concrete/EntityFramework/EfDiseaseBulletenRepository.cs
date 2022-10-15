using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfDiseaseBulletenRepository: EfRepositoryBase<DiseaseBulleten, HRDBContext>, IDiseaseBulletenRepository
    {
        public EfDiseaseBulletenRepository(HRDBContext context) : base(context)
        {
        }
    }
}
