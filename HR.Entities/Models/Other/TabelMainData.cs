namespace HR.Entities.Models.Other
{
    public class TabelMainData
    {
        public TabelMainData() { }

        public TabelMainData(int no, int employeeId, string name, string surname, string fatherName, decimal salary, string duty, string state)
        {
            No = no;
            EmployeeId = employeeId;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            Salary = salary;
            Duty = duty;
            State = state;
        }

        public int No { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public decimal Salary { get; set; }
        public string Duty { get; set; }
        public string State { get; set; }
    }
}
