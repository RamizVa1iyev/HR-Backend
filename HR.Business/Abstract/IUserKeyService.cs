using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IUserKeyService : IExtendedServiceRepository<UserKey>
    {
        int Generate(int claimId);
    }
}
