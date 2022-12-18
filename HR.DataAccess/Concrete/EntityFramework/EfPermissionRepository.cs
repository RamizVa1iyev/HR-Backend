using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfPermissionRepository : EfRepositoryBase<Permission, HRDBContext>, IPermissionRepository
    {
        public EfPermissionRepository(HRDBContext context) : base(context)
        {
        }

        public int GetDayCount(int employeeId)
        {
            var result = from p in Context.Permissions
                         where p.EmployeeId == employeeId & p.PermissionType == Entities.Constants.PermissionTypes.Day
                         join n in Context.Notifications on p.Id equals n.RecordId
                         where n.NotificationType == Entities.Constants.NotificationTypes.Permission
                         select EF.Functions.DateDiffDay(p.StartDate, p.EndDate);

            return result.ToList().Sum();
        }

        public int GetHourCount(int employeeId)
        {
            var result = from p in Context.Permissions
                         where p.EmployeeId == employeeId & p.PermissionType == Entities.Constants.PermissionTypes.Hour
                         join n in Context.Notifications on p.Id equals n.RecordId
                         where n.NotificationType == Entities.Constants.NotificationTypes.Permission
                         select EF.Functions.DateDiffDay(p.StartDate, p.EndDate);

            return result.ToList().Sum();
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
