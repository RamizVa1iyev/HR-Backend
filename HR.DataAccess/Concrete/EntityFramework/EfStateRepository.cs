using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfStateRepository : EfRepositoryBase<State, HRDBContext>, IStateRepository
    {
        public EfStateRepository(HRDBContext context) : base(context)
        {
        }
    }
}
