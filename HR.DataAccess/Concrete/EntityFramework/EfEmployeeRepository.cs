using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;


namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeRepository : EfRepositoryBase<Employee, HRDBContext>, IEmployeeRepository
    {
        public EfEmployeeRepository(HRDBContext context) : base(context)
        {
        }
    }
}
