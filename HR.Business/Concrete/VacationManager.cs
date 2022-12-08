using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class VacationManager : ManagerRepositoryBase<Vacation, IVacationRepository>, IVacationService
    {
        private readonly INotificationHelperService _notificationService;
        public VacationManager(IVacationRepository repository, INotificationHelperService notificationService) : base(repository)
        {
            base.SetValidator(new VacationValidator());
            _notificationService = notificationService;
        }

        public List<Vacation> GetVacationByEmployee(int employeeId)
        {
            return Repository.GetAll(e => e.EmployeeId == employeeId);
        }

        public override Vacation Add(Vacation entity)
        {
            var data = base.Add(entity);
            
            _notificationService.AddNotification(data);

            return data;
        }
    }
}
