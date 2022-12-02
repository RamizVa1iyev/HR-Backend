using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class DutyManager : ManagerRepositoryBase<Duty, IDutyRepository>, IDutyService
    {
        public DutyManager(IDutyRepository repository) : base(repository)
        {
            base.SetValidator(new DutyValidator());
        }
    }
}
