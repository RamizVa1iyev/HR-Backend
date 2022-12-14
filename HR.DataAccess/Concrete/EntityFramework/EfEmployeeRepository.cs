using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.Other;
using HR.Entities.Models.ResponseModels;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeRepository : EfRepositoryBase<Employee, HRDBContext>, IEmployeeRepository
    {
        public EfEmployeeRepository(HRDBContext context) : base(context)
        {
        }

        public List<EmployeeModel> GetEmployeeMainData(DateTime date)
        {
            var first = new DateTime(date.Year, date.Month, 1);
            var last = first.AddMonths(1);

            var result = from e in Context.Employees
                         where e.Status == Status.Accepted
                         join c in Context.Contracts on e.Id equals c.EmployeeId
                         where c.ContractStartDate < last & c.ContractEndDate > first
                         join d in Context.Duties on e.DutyId equals d.Id
                         join s in Context.States on d.StateId equals s.Id
                         select new EmployeeModel
                         {
                             No = 0,
                             EmployeeId = e.Id,
                             Name = e.Name,
                             Surname = e.Surname,
                             FatherName = e.FatherName,
                             Salary = d.Salary,
                             State = s.Name,
                             Duty = d.Name,
                             DailyWorkHour = e.DailyWorkHour,
                             Contract = c,
                             Overtimes = Context.Overtimes.Where(o => o.EmployeeId == e.Id & o.Date >= first & o.Date < last).ToList(),
                             Bulletens = (from b in Context.DiseaseBulletens.Where(d => d.EmployeeId == e.Id &
                                            ((d.StartDate <= first & first < d.EndDate) | (d.StartDate > first & last > d.StartDate)))
                                          join n in Context.Notifications on b.Id equals n.RecordId 
                                          where n.NotificationType == NotificationTypes.Disease & n.Status == Status.Accepted
                                          select b).ToList(),
                             Permissions = (from p in Context.Permissions.Where(p => p.EmployeeId == e.Id &
                                            ((p.StartDate <= first & first < p.EndDate) | (p.StartDate > first & last > p.StartDate)))
                                            join n in Context.Notifications on p.Id equals n.RecordId
                                            where n.NotificationType == NotificationTypes.Permission & n.Status == Status.Accepted
                                            select p).ToList(),
                             Vacations = (from v in Context.Vacations.Where(v => v.EmployeeId == e.Id &
                                            ((v.StartDate <= first & first < v.EndDate) | (v.StartDate > first & last > v.StartDate)))
                                          join n in Context.Notifications on v.Id equals n.RecordId
                                          where n.NotificationType == NotificationTypes.Vacation & n.Status == Status.Accepted
                                          select v).ToList()
                         };

            var data = result.ToList();
            int no = 1;

            data.ForEach(e =>
            {
                e.No = no++;
            });



            return data;
        }
    }
}
