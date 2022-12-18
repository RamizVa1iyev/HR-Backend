using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfVacationRepository : EfRepositoryBase<Vacation, HRDBContext>, IVacationRepository
    {
        public EfVacationRepository(HRDBContext context) : base(context)
        {
        }

        public int GetTotalVacationDayCount(int employeeId)
        {
            var result = from v in Context.Vacations where v.EmployeeId == employeeId
                         join n in Context.Notifications on v.Id equals n.RecordId
                         where n.NotificationType == Entities.Constants.NotificationTypes.Vacation
                         select EF.Functions.DateDiffDay(v.StartDate, v.EndDate);

            return result.ToList().Sum();
        }

        public List<VacationResponseModel> GetVacations(Expression<Func<Vacation, bool>> predicate = null)
        {
            var result = from vacation in predicate is null ? Context.Vacations : Context.Vacations.Where(predicate)
                         join notification in Context.Notifications on vacation.Id equals notification.RecordId
                         where notification.NotificationType == Entities.Constants.NotificationTypes.Vacation
                         select new VacationResponseModel(vacation.Id, vacation.EmployeeId, vacation.StartDate, vacation.EndDate, vacation.VacationType,
                                                          vacation.Note, notification.Status);

            return result.ToList();
        }
    }
}
