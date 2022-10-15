using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfDiseaseBulletenDal: EfRepositoryBase<DiseaseBulleten, HRDBContext>, IDiseaseBulletenDal
    {
        public EfDiseaseBulletenDal(HRDBContext context) : base(context)
        {
        }
    }
}
