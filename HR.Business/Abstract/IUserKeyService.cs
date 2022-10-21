using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IUserKeyService : IExtendedServiceRepository<UserKey>
    {
        UserKey Generate(int roleId);
        User RegisterWithKey(UserForRegisterModel user);
    }
}
