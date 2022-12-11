using Core.Entities.Concrete;
using HR.Entities.Constants;

namespace HR.Entities.Concrete
{
    public class Permission : Entity
    {
        public int EmployeeId { get; set; }
        public PermissionTypes PermissionType { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public virtual Employee? Employee { get; set; }

        public Permission()
        {

        }

        public Permission(int id, int employeeId, PermissionTypes permissionType, int count, DateTime startDate, DateTime endDate) : base(id)
        {
            EmployeeId = employeeId;
            PermissionType = permissionType;
            Count = count;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
