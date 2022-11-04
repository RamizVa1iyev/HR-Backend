using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Models.RequestModels;

namespace HR.WebApi.Controllers
{
    public class ContractController : BaseController<IContractService, Contract, ContractAddRequestModel, ContractUpdateRequestModel, ContractDeleteRequestModel>
    {
        public ContractController(IContractService service) : base(service)
        {
        }
    }
}
