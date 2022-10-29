using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfContractRepository : EfRepositoryBase<Contract, HRDBContext>, IContractRepository
    {
        public EfContractRepository(HRDBContext context) : base(context)
        {
        }
    }
}
