using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class StateManager : ManagerRepositoryBase<State, IStateRepository>, IStateService
    {
        public StateManager(IStateRepository repository) : base(repository)
        {
            base.SetValidator(new StateValidator());
        }
    }
}
