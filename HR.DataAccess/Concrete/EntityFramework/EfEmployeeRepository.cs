using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using HR.Entities.Models.Other;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeRepository : EfRepositoryBase<Employee, HRDBContext>, IEmployeeRepository
    {
        public EfEmployeeRepository(HRDBContext context) : base(context)
        {
        }

        public List<TabelMainData> GetEmployeeMainData()
        {
            var result = from e in Context.Employees
                         where e.Status == Entities.Constants.Status.Accepted
                         join d in Context.Duties on e.DutyId equals d.Id
                         join s in Context.States on d.StateId equals s.Id
                         select new TabelMainData
                         (
                             0, e.Id, e.Name, e.Surname, e.FatherName, d.Salary, s.Name, s.Name
                         );

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
