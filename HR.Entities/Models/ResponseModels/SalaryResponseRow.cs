namespace HR.Entities.Models.ResponseModels
{
    public class SalaryResponseRow
    {
        public SalaryResponseRow() { }
        public SalaryResponseRow(int no, string name, string surname, string fatherName, string duty, decimal salary, int totalWorkHours, int workHours, decimal computedSalary, decimal reward, decimal vacation, decimal sumSalary, decimal incomingTax, decimal pensionFond, decimal iSH, decimal iTSH, decimal totalTax, decimal valueToPaid)
        {
            No = no;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            Duty = duty;
            Salary = salary;
            TotalWorkHours = totalWorkHours;
            WorkHours = workHours;
            ComputedSalary = computedSalary;
            Reward = reward;
            Vacation = vacation;
            SumSalary = sumSalary;
            IncomingTax = incomingTax;
            PensionFond = pensionFond;
            ISH = iSH;
            ITSH = iTSH;
            TotalTax = totalTax;
            ValueToPaid = valueToPaid;
        }

        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Duty { get; set; }
        public decimal Salary { get; set; }
        public int TotalWorkHours { get; set; }
        public int WorkHours { get; set; }
        public decimal ComputedSalary { get; set; }
        public decimal Reward { get; set; }
        public decimal Vacation { get; set; }
        public decimal SumSalary { get; set; }
        public decimal IncomingTax { get; set; }
        public decimal PensionFond { get; set; }
        public decimal ISH { get; set; }
        public decimal ITSH { get; set; }
        public decimal TotalTax { get; set; }
        public decimal ValueToPaid { get; set; }
    }
}
