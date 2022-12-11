using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using HR.Business.Abstract;
using HR.Entities.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IEmployeeService _employeeService;

        public AuthController(IAuthService authService, IUserService userService, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService, IEmployeeService employeeService)
        {
            _authService = authService;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
            _operationClaimService = operationClaimService;
            _employeeService = employeeService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginModel userForLoginModel)
        {
            var userToLogin = _authService.Login(userForLoginModel);
            var accessToken = _authService.CreateAccessToken(userToLogin);

            var result = new UserLoginResponseModel(userToLogin,accessToken);
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterModel userForRegisterModel)
        {
            var userToRegister = _authService.Register(userForRegisterModel);
            var accessToken = _authService.CreateAccessToken(userToRegister);
            var result = new UserRegisterResponseModel(userToRegister, accessToken);
            return Ok(result);
        }

        [HttpPost("registercheck")]
        public IActionResult RegisterCheck(UserForRegisterCheckRequestModel user)
        {
            return Ok(_authService.RegisterCheck(user));
        }

        [HttpGet("getroles")]
        public IActionResult GetRoles(int userId)
        {
            var response = new UserRoleResponseModel
                (_userService.GetClaims(new User { Id = userId }), _employeeService.GetByUserId(userId).Id);
            return Ok(response);
        }

        [HttpGet("getallroles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_operationClaimService.GetAll());
        }

        [HttpGet("getallusers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            var employees = _employeeService.GetAll();
            var result = from user in users
                         where user.Status
                         join employee in employees on user.Id equals employee.UserId
                         where employee.Status == Entities.Constants.Status.Accepted
                         select new UserResponseModel(user.Id, user.FirstName, user.LastName, user.Email, user.PasswordHash, user.PasswordSalt, user.Status, employee.Id);

            return Ok(result.ToList());
        }

        [HttpPost("editinfo")]
        public IActionResult EditCommonUserInfo(UserUpdateRequestModel user)
        {
            var userToUpdate = Map<UserUpdateRequestModel, User>(user);
            return Ok(_userService.UpdateCommonInfos(userToUpdate));
        }

        [HttpPost("switchuserstatus")]
        public IActionResult BanUser(int userId, bool val)
        {
            return Ok(_userService.BanUser(userId, val));
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(UserUpdatePasswordRequestModel user)
        {
            return Ok(_userService.UpdatePassword(user));
        }

        private TTarget Map<TCurrent, TTarget>(TCurrent source)
        {
            var data = Activator.CreateInstance<TTarget>();

            var targetProperties = source.GetType().GetProperties();
            var destinationProperties = data.GetType().GetProperties();

            foreach (var dp in destinationProperties)
            {
                var val = targetProperties.FirstOrDefault(p => p.Name == dp.Name)?.GetValue(source);
                dp.SetValue(data, val);
            }

            return data;
        }
    }
}