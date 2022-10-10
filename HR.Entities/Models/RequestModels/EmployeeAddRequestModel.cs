using Core.Entities.Abstract;
using HR.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class EmployeeAddRequestModel : IAddModel
    {
        public int DailyWorkHour { get; set; }
        public int OperatingMode { get; set; }
        public int Status { get; set; }

        public EmployeeAddRequestModel()
        {

        }

        public EmployeeAddRequestModel(int id, int dailyWorkHour, int operatingMode, int status)
        {
            DailyWorkHour = dailyWorkHour;
            OperatingMode = operatingMode;
            Status = status;
        }
    }
}
