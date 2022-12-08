using Core.Business.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Abstract
{
    public interface IOvertimeService : IExtendedServiceRepository<Overtime>
    {
        List<Overtime> GetOvertimeByEmployee(int employeeId);
    }
}
