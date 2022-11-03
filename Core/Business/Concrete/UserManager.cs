using Core.Business.Abstract;
using Core.Business.Validation;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.Features.Security.Hashing;

namespace Core.Business.Concrete
{
    public partial class UserManager : ManagerRepositoryBase<User, IUserRepository>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            base.SetValidator(new UserValidator());
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }

        public User UpdateCommonInfos(User user)
        {
            var data = Repository.Get(u => u.Id == user.Id);
            user.PasswordSalt = data.PasswordSalt;
            user.PasswordHash = data.PasswordHash;

            return Repository.Update(user);
        }

        public User BanUser(int userId, bool value)
        {
            var data = Repository.Get(u => u.Id == userId);
            data.Status = value;
            return Repository.Update(data);
        }

        public User UpdatePassword(UserUpdatePasswordRequestModel user)
        {
            var data = Repository.Get(u => u.Id == user.UserId);
            HashingHelper.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            data.PasswordSalt = passwordSalt;
            data.PasswordHash = passwordHash;

            return Repository.Update(data);
        }
    }
}
