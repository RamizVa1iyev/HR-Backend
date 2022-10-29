using Core.Business.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Abstract
{
    public interface IContractService: IExtendedServiceRepository<Contract>
    {
        string GenerateContractNumber();
    }
}
