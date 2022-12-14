using Core.Aspects.Autofac.Caching;
using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Concrete
{
    public class DiseaseBulletenManager : ManagerRepositoryBase<DiseaseBulleten, IDiseaseBulletenRepository>, IDiseaseBulletenService
    {
        private readonly INotificationHelperService _notificationService;
        public DiseaseBulletenManager(IDiseaseBulletenRepository repository, INotificationHelperService notificationService) : base(repository)
        {
            base.SetValidator(new DiseaseBulletinValidator());
            _notificationService = notificationService;
        }

        [CacheAspect]
        public List<DiseaseBulleten> GetDiseaseBulletenByEmployee(int employeeId)
        {
            return Repository.GetAll(d => d.EmployeeId == employeeId);
        }

        public override DiseaseBulleten Add(DiseaseBulleten entity)
        {
            entity.CreateDate = DateTime.Now;
            var data = base.Add(entity);

            _notificationService.AddNotification(data);

            return data;
        }

        public override DiseaseBulleten Update(DiseaseBulleten entity)
        {
            var data = base.Get(entity.Id);
            data = new DiseaseBulleten(entity.Id, entity.EmployeeId, entity.StartDate, entity.EndDate, entity.Note, 
                                        entity.DocumentNumber, data.CreateDate, entity.ClinicName, entity.PayPercent);

            return base.Update(data);
        }

        [CacheAspect]
        public List<DiseaseResponseModel> GetDiseases(int employeeId)
        {
            return Repository.GetDiseases(e => e.EmployeeId == employeeId);
        }
    }
}
