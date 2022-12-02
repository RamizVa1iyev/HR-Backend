using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class DiseaseBulletenManager : ManagerRepositoryBase<DiseaseBulleten, IDiseaseBulletenRepository>, IDiseaseBulletenService
    {
        public DiseaseBulletenManager(IDiseaseBulletenRepository repository) : base(repository)
        {
            base.SetValidator(new DiseaseBulletinValidator());
        }

        public List<DiseaseBulleten> GetDiseaseBulletenByEmployee(int employeeId)
        {
            return Repository.GetAll(d => d.EmployeeId == employeeId);
        }
    }
}
