using Core.Business.Concrete;
using Core.CCC.Exception;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

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
            CheckQuota(entity);

            var data = base.Add(entity);
            
            _notificationService.AddNotification(data);

            return data;
        }

        public override Vacation Update(Vacation entity)
        {
            CheckQuota(entity);
            return base.Update(entity);
        }

        public List<VacationResponseModel> GetVacations(int employeeId)
        {
            return Repository.GetVacations(v => v.EmployeeId == employeeId);
        }

        private void CheckQuota(Vacation entity)
        {
            var totalVacationDays = Repository.GetTotalVacationDayCount(entity.EmployeeId);

            if (totalVacationDays + (entity.EndDate - entity.StartDate).TotalDays > 21)
                throw new BusinessException("Quota exceeded. Max day count is 21. You have: " + totalVacationDays);
        }
    }
}
