using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IVacationService : IExtendedServiceRepository<Vacation>
    {
        List<Vacation> GetVacationByEmployee(int employeeId);
    }
}
