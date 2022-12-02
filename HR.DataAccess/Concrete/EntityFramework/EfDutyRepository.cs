using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfDutyRepository : EfRepositoryBase<Duty, HRDBContext>, IDutyRepository
    {
        public EfDutyRepository(HRDBContext context) : base(context)
        {

        }
    }
}
