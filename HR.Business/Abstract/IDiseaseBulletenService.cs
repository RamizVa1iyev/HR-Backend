using Core.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Abstract
{
    public interface IDiseaseBulletenService : IExtendedServiceRepository<DiseaseBulleten>
    {
        List<DiseaseBulleten> GetDiseaseBulletenByEmployee(int employeeId);
        List<DiseaseResponseModel> GetDiseases(int employeeId);
    }
}
