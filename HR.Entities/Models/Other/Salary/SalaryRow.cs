namespace HR.Entities.Models.Other.Salary
{
    public class SalaryRow
    {
        public string this[int index]
        {
            get
            {
                if(index < 0 | index > 17)
                    throw new IndexOutOfRangeException();

                switch (index)
                {
                    case 0:
                        return No.ToString();
                    case 1:
                        return Name;
                    case 2:
                        return Surname;
                    case 3:
                        return FatherName;
                    case 4:
                        return Duty;
                    case 5:
                        return Salary.ToString();
                    case 6:
                        return TotalWorkHours.ToString();
                    case 7:
                        return WorkHours.ToString();
                    case 8:
                        return ComputedSalary.ToString();
                    case 9:
                        return Reward.ToString();
                    case 10:
                        return Vacation.ToString();
                    case 11:
                        return SumSalary.ToString();
                    case 12:
                        return IncomingTax.ToString();
                    case 13:
                        return PensionFond.ToString();
                    case 14:
                        return ISH.ToString();
                    case 15:
                        return ITSH.ToString();
                    case 16:
                        return TotalTax.ToString();
                    case 17:
                        return ValueToPaid.ToString();
                    default:
                        return null;
                }
            }
            set
            {
            }
        }

        public SalaryRow() { }
        public SalaryRow(int no, string name, string surname, string fatherName, string duty, decimal salary, int totalWorkHours, int workHours, decimal computedSalary, decimal reward, decimal vacation, decimal sumSalary, decimal incomingTax, decimal pensionFond, decimal iSH, decimal iTSH, decimal totalTax, decimal valueToPaid)
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
