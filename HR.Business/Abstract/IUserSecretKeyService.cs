using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IUserSecretKeyService : IExtendedServiceRepository<UserSecretKey>
    {
        string GenerateSecretKey(int claimId);
    }
}
