using Core.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Abstract
{
    public interface IPermissionService : IExtendedServiceRepository<Permission>
    {
        List<Permission> GetPermissionByEmployee(int employeeId);
        List<PermissionResponseModel> GetPermissions(int employeeId);
    }
}
