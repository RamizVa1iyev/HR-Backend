using Core.Entities.Abstract;
using Core.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Entities.Models.ResponseModels
{
    public class UserRoleResponseModel : IModel
    {
        public UserRoleResponseModel(List<OperationClaim> operationClaims, int employeeId, Status status)
        {
            OperationClaims = operationClaims;
            EmployeeId = employeeId;
            Status = status;
        }

        public List<OperationClaim> OperationClaims { get; set; }
        public int EmployeeId { get; set; }
        public Status Status { get; set; }
    }
}
