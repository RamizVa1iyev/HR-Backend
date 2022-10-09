using Core.Entities.Concrete;

namespace Core.Business.Abstract
{
    public interface IUserService : IExtendedServiceRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        string GenerateSecretCode(int claimId);
    }
}
