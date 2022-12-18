using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using HR.Entities.Models.Other;

namespace HR.DataAccess.Abstract
{
    public interface IEmployeeRepository : IExtendedRepository<Employee>
    {
        List<TabelMainData> GetEmployeeMainData();
    }
}
