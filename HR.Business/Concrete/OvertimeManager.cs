using Core.Aspects.Autofac.Caching;
using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class OvertimeManager : ManagerRepositoryBase<Overtime, IOvertimeRepository>, IOvertimeService
    {
        public OvertimeManager(IOvertimeRepository repository) : base(repository)
        {
            base.SetValidator(new OvertimeValidator());
        }

        [CacheAspect]
        public List<Overtime> GetOvertimeByEmployee(int employeeId)
        {
            return Repository.GetAll(o => o.EmployeeId == employeeId);
        }
    }
}
