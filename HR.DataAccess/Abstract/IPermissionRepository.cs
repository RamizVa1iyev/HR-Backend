using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace HR.DataAccess.Abstract
{
    public interface IPermissionRepository : IExtendedRepository<Permission>
    {
        int GetDayCount(int employeeId);
        int GetHourCount(int employeeId);
        List<PermissionResponseModel> GetPermissions(Expression<Func<Permission, bool>> predicate = null);
    }
}
