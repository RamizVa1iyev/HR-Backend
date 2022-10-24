using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeRewardRepository : EfRepositoryBase<EmployeeReward, HRDBContext>, IEmployeeRewardRepository
    {
        public EfEmployeeRewardRepository(HRDBContext context) : base(context)
        {
        }
    }
}
