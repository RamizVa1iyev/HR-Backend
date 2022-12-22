using Core.Aspects.Autofac.Caching;
using Core.Business.Abstract;
using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Concrete
{
    public class EmployeeManager : ManagerRepositoryBase<Employee, IEmployeeRepository>, IEmployeeService
    {
        private readonly IUserService _userService;
        public EmployeeManager(IEmployeeRepository repository, IUserService userService) : base(repository)
        {
            base.SetValidator(new EmployeeValidator());
            _userService = userService;
        }

        [CacheAspect]
        public Employee GetByUserId(int userId)
        {
            return Repository.Get(e => e.UserId == userId);
        }

        [CacheAspect]
        public List<Employee> GetEmployeeByDuty(int dutyId)
        {
            return Repository.GetAll(e => e.DutyId == dutyId);
        }

        [CacheAspect]
        public List<Employee> GetEmployeeByUser(int userId)
        {
            return Repository.GetAll(e => e.UserId == userId);
        }

        [CacheAspect]
        public List<EmployeeModel> GetEmployeeMainData(DateTime date)
        {
            return Repository.GetEmployeeMainData(date);
        }
        
        [CacheRemoveAspect("get")]
        public Employee SetStatus(int employeeId, Status status)
        {
            var employee = base.Get(employeeId);
            employee.Status = status;

            return Repository.Update(employee);
        }

        [CacheRemoveAspect("get")]
        public Employee ChangeWorkStatus(int employeeId, bool value)
        {
            var employee = base.Get(employeeId);

            if (value)
                employee.Status = Status.Accepted;
            else
                employee.Status = Status.Rejected;

            employee = Repository.Update(employee);

            _userService.BanUser(employee.UserId, value);

            return employee;
        }

    }
}
