using Core.Entities.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class PermissionAddRequestModel : IAddModel
    {
        public int EmployeeId { get; set; }
        public PermissionTypes PermissionType { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PermissionAddRequestModel()
        {

        }

        public PermissionAddRequestModel(int employeeId, PermissionTypes permissionType, int count, DateTime startDate, DateTime endDate)
        {
            EmployeeId = employeeId;
            PermissionType = permissionType;
            Count = count;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
