using Core.Business.Concrete;
using FluentValidation;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Concrete
{
    public class EmployeeManager : ManagerRepositoryBase<Employee, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeManager(IEmployeeRepository repository) : base(repository)
        {
            base.SetValidator(new EmployeeValidator());
        }

        public List<Employee> GetEmployeeByDuty(int dutyId)
        {
           return Repository.GetAll(e=>e.DutyId == dutyId);
        }

        public List<Employee> GetEmployeeByUser(int userId)
        {
            return Repository.GetAll(e => e.UserId == userId);
        }
    }
}
