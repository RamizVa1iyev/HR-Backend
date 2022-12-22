using Core.Business.Concrete;
using FluentValidation;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.Other;
using HR.Entities.Models.ResponseModels;
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

        public Employee GetByUserId(int userId)
        {
            return Repository.Get(e => e.UserId== userId);
        }

        public List<Employee> GetEmployeeByDuty(int dutyId)
        {
           return Repository.GetAll(e=>e.DutyId == dutyId);
        }

        public List<Employee> GetEmployeeByUser(int userId)
        {
            return Repository.GetAll(e => e.UserId == userId);
        }

        public List<EmployeeModel> GetEmployeeMainData(DateTime date)
        {
            return Repository.GetEmployeeMainData(date);
        }

        public Employee SetStatus(int employeeId, Status status)
        {
            var employee = base.Get(employeeId);
            employee.Status = status;

            return Repository.Update(employee);
        }
    }
}
