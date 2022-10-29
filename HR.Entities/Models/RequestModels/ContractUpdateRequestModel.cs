
namespace HR.Entities.Models.RequestModels
{
    public class ContractUpdateRequestModel
    {
        public int Id { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractNumber { get; set; }
        public long EmployeeId { get; set; }
        public ContractUpdateRequestModel()
        {

        }

        public ContractUpdateRequestModel(int id,DateTime contractStartDate, DateTime contractEndDate, string contractNumber, long employeeId)
        {
            Id = id;
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            ContractNumber = contractNumber;
            EmployeeId = employeeId;
        }
    }
}
