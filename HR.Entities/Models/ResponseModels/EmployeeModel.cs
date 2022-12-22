using HR.Entities.Concrete;

namespace HR.Entities.Models.ResponseModels
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {

        }

        public EmployeeModel(int no, int employeeId, string name, string surname, string fatherName, decimal salary, string duty, string state, int dailyWorkHour, Contract contract)
        {
            No = no;
            EmployeeId = employeeId;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            Salary = salary;
            Duty = duty;
            State = state;
            DailyWorkHour = dailyWorkHour;
            Contract = contract;
        }

        public int No { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public decimal Salary { get; set; }
        public string Duty { get; set; }
        public string State { get; set; }
        public int DailyWorkHour { get; set; }

        public Contract Contract { get; set; }
        public List<Overtime> Overtimes { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<DiseaseBulleten> Bulletens { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
