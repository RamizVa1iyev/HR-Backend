using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfPermissionRepository : EfRepositoryBase<Permission, HRDBContext>, IPermissionRepository
    {
        public EfPermissionRepository(HRDBContext context) : base(context)
        {
        }

        public List<PermissionResponseModel> GetPermissions(Expression<Func<Permission, bool>> predicate = null)
        {
            var result = from permission in predicate is null ? Context.Permissions : Context.Permissions.Where(predicate)
                         join notification in Context.Notifications on permission.Id equals notification.RecordId
                         where notification.NotificationType == Entities.Constants.NotificationTypes.Permission
                         select new PermissionResponseModel(permission.Id, permission.EmployeeId, permission.PermissionType, permission.Count,
                                                            permission.StartDate, permission.EndDate, notification.Status);

            return result.ToList();
        }
    }
}
