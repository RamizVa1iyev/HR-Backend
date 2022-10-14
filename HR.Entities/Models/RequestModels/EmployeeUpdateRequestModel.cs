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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string FinCode { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public int DutyId { get; set; }
        public DateTime BirthDay { get; set; }
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
