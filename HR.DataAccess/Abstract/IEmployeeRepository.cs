using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using HR.Entities.Models.Other;
using HR.Entities.Models.ResponseModels;

namespace HR.DataAccess.Abstract
{
    public interface IEmployeeRepository : IExtendedRepository<Employee>
    {
        List<EmployeeModel> GetEmployeeMainData(DateTime date);
    }
}
