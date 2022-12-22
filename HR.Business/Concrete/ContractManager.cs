using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class ContractManager : ManagerRepositoryBase<Contract, IContractRepository>, IContractService
    {
        public ContractManager(IContractRepository repository) : base(repository)
        {
            base.SetValidator(new ContractValidator());
        }

        public string GenerateContractNumber()
        {
            int nextId = base.Repository.GetNextId();
            return String.Format("CN-{0}-{1}",DateTime.Now.Year.ToString().Substring(2),nextId.ToString("0000"));
        }
        public override Contract Add(Contract entity)
        {
            entity.ContractNumber = GenerateContractNumber();
            return base.Add(entity);
        }
        public override Task<Contract> AddAsync(Contract entity)
        {
            entity.ContractNumber = GenerateContractNumber();
            return base.AddAsync(entity);
        }
    }
}
