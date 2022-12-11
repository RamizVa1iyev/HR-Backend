using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace HR.DataAccess.Abstract
{
    public interface IDiseaseBulletenRepository: IExtendedRepository<DiseaseBulleten>
    {
        List<DiseaseResponseModel> GetDiseases(Expression<Func<DiseaseBulleten, bool>> predicate = null);
    }
}
