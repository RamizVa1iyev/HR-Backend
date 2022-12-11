using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace HR.DataAccess.Abstract
{
    public interface IPermissionRepository : IExtendedRepository<Permission>
    {
        List<PermissionResponseModel> GetPermissions(Expression<Func<Permission, bool>> predicate = null);
    }
}
