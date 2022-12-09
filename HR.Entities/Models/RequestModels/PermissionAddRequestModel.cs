using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.RequestModels
{
    public class PermissionAddRequestModel : IAddModel
    {
        public int EmployeeId { get; set; }
        public PermissionTypes PermissionType { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }

        public PermissionAddRequestModel()
        {

        }

        public PermissionAddRequestModel(int employeeId, PermissionTypes permissionType, int count, DateTime startDate)
        {
            EmployeeId = employeeId;
            PermissionType = permissionType;
            Count = count;
            StartDate = startDate;
        }
    }
}
