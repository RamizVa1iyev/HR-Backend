using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace HR.DataAccess.Abstract
{
    public interface IVacationRepository : IExtendedRepository<Vacation>
    {
        int GetTotalVacationDayCount(int employeeId);
        List<VacationResponseModel> GetVacations(Expression<Func<Vacation, bool>> predicate = null);
    }
}
