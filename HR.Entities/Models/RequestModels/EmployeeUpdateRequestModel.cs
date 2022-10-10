using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class EmployeeUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }            
        public int DailyWorkHour { get; set; }
        public int OperatingMode { get; set; }
        public int Status { get; set; }

        public EmployeeUpdateRequestModel()
        {

        }

        public EmployeeUpdateRequestModel(int id, int dailyWorkHour, int operatingMode, int status) 
        {
            DailyWorkHour = dailyWorkHour;
            OperatingMode = operatingMode;
            Status = status;
        }
    }
}
