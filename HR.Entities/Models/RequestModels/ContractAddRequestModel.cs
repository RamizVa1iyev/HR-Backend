
namespace HR.Entities.Models.RequestModels
{
    public class ContractAddRequestModel
    {
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractNumber { get; set; }
        public long EmployeeId { get; set; }
        public ContractAddRequestModel()
        {

        }

        public ContractAddRequestModel(DateTime contractStartDate, DateTime contractEndDate, string contractNumber, long employeeId)
        {
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            ContractNumber = contractNumber;
            EmployeeId = employeeId;
        }
    }
}
