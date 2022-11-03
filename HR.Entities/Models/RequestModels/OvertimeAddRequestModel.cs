using Core.Entities.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class OvertimeAddRequestModel : IAddModel
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int HourCount { get; set; }

        public OvertimeAddRequestModel()
        {

        }

        public OvertimeAddRequestModel(int employeeId, DateTime date, int hourCount)
        {
            EmployeeId = employeeId;
            Date = date;
            HourCount = hourCount;
        }
    }
}
