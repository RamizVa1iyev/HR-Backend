using Core.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.Other;

namespace HR.Business.Abstract
{
    public interface IEmployeeService : IExtendedServiceRepository<Employee>
    {
        Employee SetStatus(int employeeId, Status status);
        Employee GetByUserId(int userId);
        List<Employee> GetEmployeeByDuty(int dutyId);
        List<Employee> GetEmployeeByUser(int userId);

        List<TabelMainData> GetEmployeeMainData();
    }
}
