using Core.Business.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Abstract
{
    public interface IEmployeeService : IExtendedServiceRepository<Employee>
    {
        List<Employee> GetEmployeeByUser(int userId);
        List<Employee> GetEmployeeByDuty(int dutyId);
    }
}
