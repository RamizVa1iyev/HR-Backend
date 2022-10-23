using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.WebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController<IUserOperationClaimService, UserOperationClaim, UserOperationClaimAddRequestModel, UserOperationClaimUpdateRequestModel, UserOperationClaimDeleteRequestModel>
    {
        public UserOperationClaimsController(IUserOperationClaimService service) : base(service)
        {
        }


    }
}
