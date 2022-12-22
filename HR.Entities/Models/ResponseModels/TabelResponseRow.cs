using Core.Entities.Abstract;

namespace HR.Entities.Models.ResponseModels
{
    public class TabelResponseRow : IModel
    {
        public TabelResponseRow() { }
        public TabelResponseRow(int no, string name, string surname, string fatherName, decimal salary, string duty, string state, List<string> days, int totalWorkDays, int totalWorkHours, int vacationDays, int diseaseDays, int overtime)
        {
            No = no;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            Salary = salary;
            Duty = duty;
            State = state;
            Days = days;
            TotalWorkDays = totalWorkDays;
            TotalWorkHours = totalWorkHours;
            VacationDays = vacationDays;
            DiseaseDays = diseaseDays;
            Overtime = overtime;
        }

        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public decimal Salary { get; set; }
        public string Duty { get; set; }
        public string State { get; set; }
        public List<string> Days { get; set; }
        public int TotalWorkDays { get; set; }
        public int TotalWorkHours { get; set; }
        public int VacationDays { get; set; }
        public int DiseaseDays { get; set; }
        public int Overtime { get; set; }
    }
}
