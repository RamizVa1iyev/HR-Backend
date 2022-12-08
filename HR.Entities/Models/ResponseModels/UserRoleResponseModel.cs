using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace HR.Entities.Models.ResponseModels
{
    public class UserRoleResponseModel : IModel
    {
        public UserRoleResponseModel(List<OperationClaim> operationClaims, int employeeId)
        {
            OperationClaims = operationClaims;
            EmployeeId = employeeId;
        }

        public List<OperationClaim> OperationClaims { get; set; }
        public int EmployeeId { get; set; }
    }
}
