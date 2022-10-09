using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class UserSecretKeyManager : ManagerRepositoryBase<UserSecretKey, IUserSecretKeyRepository>, IUserSecretKeyService
    {
        protected UserSecretKeyManager(IUserSecretKeyRepository repository) : base(repository)
        {
            base.SetValidator(new UserSecretKeyValidator());
        }

        public string GenerateSecretKey(int claimId)
        {
            throw new NotImplementedException();
        }
    }
}
