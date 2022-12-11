using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;
using System.Linq.Expressions;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfDiseaseBulletenRepository: EfRepositoryBase<DiseaseBulleten, HRDBContext>, IDiseaseBulletenRepository
    {
        public EfDiseaseBulletenRepository(HRDBContext context) : base(context)
        {
        }

        public List<DiseaseResponseModel> GetDiseases(Expression<Func<DiseaseBulleten, bool>> predicate = null)
        {
            var result = from disease in predicate is null ? Context.DiseaseBulletens : Context.DiseaseBulletens.Where(predicate)
                         join notification in Context.Notifications on disease.Id equals notification.RecordId
                                where notification.NotificationType == Entities.Constants.NotificationTypes.Disease
                         select new DiseaseResponseModel(disease.Id, disease.EmployeeId, disease.StartDate, disease.EndDate, disease.Note,
                                                         disease.DocumentNumber, disease.CreateDate, disease.ClinicName, disease.PayPercent, notification.Status);

            return result.ToList();
        }
    }
}
