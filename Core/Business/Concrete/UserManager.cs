﻿using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;

namespace Core.Business.Concrete
{
    public partial class UserManager : ManagerRepositoryBase<User, IUserRepository>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }

        public string GenerateSecretCode(int claimId)
        {
            throw new NotImplementedException();
        }
    }
}
