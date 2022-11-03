using Core.Entities.Concrete;
using Core.Entities.Models;

namespace Core.Business.Abstract
{
    public interface IUserService : IExtendedServiceRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        User UpdateCommonInfos(User user);
        User BanUser(int userId, bool value);
        User UpdatePassword(UserUpdatePasswordRequestModel user);
    }
}
