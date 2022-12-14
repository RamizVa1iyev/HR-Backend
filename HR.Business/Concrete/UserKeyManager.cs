using Core.Aspects.Autofac.Caching;
using Core.Business.Abstract;
using Core.Business.Concrete;
using Core.Entities.Concrete;
using Core.Entities.Models;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Business.Concrete
{
    public class UserKeyManager : ManagerRepositoryBase<UserKey, IUserKeyRepository>, IUserKeyService
    {
        private readonly IAuthService _authService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IEmployeeService _employeeService;
        private readonly INotificationHelperService _notificationService;
        private readonly IContractService _contractService;

        public UserKeyManager(IUserKeyRepository repository, IAuthService authService, IUserOperationClaimService userOperationClaimService, IEmployeeService employeeService, INotificationHelperService notificationService, IContractService contractService) : base(repository)
        {
            base.SetValidator(new UserKeyValidator());
            _authService = authService;
            _userOperationClaimService = userOperationClaimService;
            _employeeService = employeeService;
            _notificationService = notificationService;
            _contractService = contractService;
        }

        [CacheRemoveAspect("get")]
        public UserKey Generate(int roleId)
        {
            var key = GenerateSecretKey(roleId);

            var userKey = new UserKey
            {
                UserId = 0,
                SecretKey = key,
                CreateDate = DateTime.Now,
                IsUsed = false
            };

            return base.Add(userKey);
        }

        private string GenerateSecretKey(int roleId)
        {
            var objId = Repository.GetNextId();
            var key = new Random().Next(0, (int)Math.Pow(10, 9)).ToString("D9");
            var roleHex = GetHex(roleId);
            var keyList = SplitNumbers(key);
            int target;

            if(objId % keyList.Count == 0)
            {
                keyList[8] = roleHex[0].ToString();
                keyList[0] = roleHex[1].ToString();
            }
            else
            {
                for (int i = 0; i < roleHex.Count; i++)
                {
                    target = (objId % keyList.Count) - 1;

                    keyList[target] = roleHex[i].ToString();
                    objId *= 2;
                }
            }
            
            return string.Join("", keyList);
        }

        private int ParseToken(string token)
        {
            int target, tokenId = Repository.Get(k => k.SecretKey == token.Trim()).Id;

            var roleHex = "";
            var keyList = SplitNumbers(token);

            if(tokenId % keyList.Count == 0)
            {
                roleHex = keyList[8].ToString() + keyList[0].ToString();
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    target = (tokenId % keyList.Count) - 1;
                    roleHex += token[target];
                    tokenId *= 2;
                }
            }
            
            return GetDecimal(roleHex);
        }

        private List<int> GetHex(int n)
        {
            var result = new List<int>();

            while (n != 0)
            {
                result.Add(n % 8);
                n /= 8;
            }
            int count = result.Count;
            for (int i = 0; i < 2 - count; i++)
            {
                result.Add(0);
            }
            return result.Reverse<int>().ToList();
        }

        private int GetDecimal(string hex)
        {
            int result = 0;

            for (int i = 0; i < hex.Length; i++)
            {
                result += (int)Math.Pow(8, hex.Length - 1 - i) * int.Parse(hex[i].ToString());
            }

            return result;
        }

        private List<string> SplitNumbers(string key)
        {
            var result = new List<string>();

            for (int i = 0; i < key.Length; i++)
            {
                result.Add(key[i].ToString());
            }

            return result;
        }

        [CacheRemoveAspect("get")]
        public User RegisterWithKey(UserForRegisterModel user)
        {
            var key = Repository.GetByKey(user.Code);

            if (key is null)
                throw new Exception("Key not found");

            int roleId = ParseToken(user.Code);

            var data = _authService.Register(user);

            _userOperationClaimService.Add(new UserOperationClaim { OperationClaimId = roleId, UserId = data.Id });
            key.UserId = data.Id;
            key.IsUsed = true;
            Repository.Update(key);

            var employee = new Employee(0, data.FirstName, data.LastName, "", "", data.Id, "", "", 0, 0, DateTime.MinValue, 0, 0, Status.Pending, 0, 0);

            employee = _employeeService.Add(employee);

            _notificationService.AddNotification(employee);

            _contractService.Add(new Contract(0, DateTime.Now, DateTime.Now.AddYears(3), employee.Id));

            return data;
        }
    }
}
