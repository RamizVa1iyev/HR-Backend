using Core.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Abstract
{
    public interface IVacationService : IExtendedServiceRepository<Vacation>
    {
        List<Vacation> GetVacationByEmployee(int employeeId);
        List<VacationResponseModel> GetVacations(int employeeId);
    }
}
