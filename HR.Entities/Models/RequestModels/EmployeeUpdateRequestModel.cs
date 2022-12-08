using Core.Entities.Abstract;
using HR.Entities.Constants;

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
        public Status Status { get; set; }
        public int PreviousExperienceYear { get; set; }
        public int PreviousExperienceMonth { get; set; }
        public EmployeeUpdateRequestModel()
        {

        }

        public EmployeeUpdateRequestModel(int id, string name, string surname, string fatherName, string finCode, int userId,
            string address, string phone, int gender, int dutyId, DateTime birthDay, int dailyWorkHour, int operatingMode,
            Status status, int previousExperienceYear, int previousExperienceMonth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            FinCode = finCode;
            UserId = userId;
            Address = address;
            Phone = phone;
            Gender = gender;
            DutyId = dutyId;
            BirthDay = birthDay;
            DailyWorkHour = dailyWorkHour;
            OperatingMode = operatingMode;
            Status = status;
            PreviousExperienceYear = previousExperienceYear;
            PreviousExperienceMonth = previousExperienceMonth;
        }
    }
}
