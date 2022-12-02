using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class VacationManager : ManagerRepositoryBase<Vacation, IVacationRepository>, IVacationService
    {
        public VacationManager(IVacationRepository repository) : base(repository)
        {
            base.SetValidator(new VacationValidator());
        }

        public List<Vacation> GetVacationByEmployee(int employeeId)
        {
            return Repository.GetAll(e => e.EmployeeId == employeeId);
        }
    }
}
