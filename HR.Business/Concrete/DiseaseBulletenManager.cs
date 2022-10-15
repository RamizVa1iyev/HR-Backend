using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class DiseaseBulletenManager : ManagerRepositoryBase<DiseaseBulleten, IDiseaseBulletenDal>, IDiseaseBulletenService
    {
        public DiseaseBulletenManager(IDiseaseBulletenDal repository) : base(repository)
        {
            base.SetValidator(new DiseaseBulletinValidator());
        }
    }
}
