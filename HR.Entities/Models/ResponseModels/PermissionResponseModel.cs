using Core.Entities.Abstract;
using HR.Entities.Constants;

namespace HR.Entities.Models.ResponseModels
{
    public class PermissionResponseModel : IModel
    {
        public PermissionResponseModel() { }
        public PermissionResponseModel(int id, int employeeId, PermissionTypes permissionType, int count, DateTime startDate, DateTime endDate, Status status)
        {
            Id = id;
            EmployeeId = employeeId;
            PermissionType = permissionType;
            Count = count;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public PermissionTypes PermissionType { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }
}
