using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IEmployeeService : IExtendedServiceRepository<Employee>
    {
        Employee GetByUserId(int userId);
        List<Employee> GetEmployeeByDuty(int dutyId);
        List<Employee> GetEmployeeByUser(int userId);
    }
}
