using Core.Entities.Abstract;
using HR.Entities.Constants;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class PermissionUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public PermissionTypes PermissionType { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PermissionUpdateRequestModel()
        {

        }

        public PermissionUpdateRequestModel(int employeeId, PermissionTypes permissionType, int count, DateTime startDate, DateTime endDate)
        {
            EmployeeId = employeeId;
            PermissionType = permissionType;
            Count = count;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
