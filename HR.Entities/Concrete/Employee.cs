using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class Employee : Entity
    {
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

        public Employee()
        {

        }

        public Employee(int id, string name, string surname, string fatherName, string finCode, int userId, string address, string phone, int gender, int dutyId, DateTime birthDay, int dailyWorkHour, int operatingMode, int status) : base(id)
        {
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
        }
    }
}
