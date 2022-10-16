using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class OvertimeUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int HourCount { get; set; }

        public OvertimeUpdateRequestModel()
        {

        }

        public OvertimeUpdateRequestModel(int employeeId, DateTime date, int hourCount)
        {
            EmployeeId = employeeId;
            Date = date;
            HourCount = hourCount;
        }
    }
}
