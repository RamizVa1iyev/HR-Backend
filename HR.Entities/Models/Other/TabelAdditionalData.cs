namespace HR.Entities.Models.Other
{
    public class TabelAdditionalData
    {
        public TabelAdditionalData() { }
        public TabelAdditionalData(int totalWorkDays, int totalWorkHours, int vacationDays, int diseaseDays, int overtime, int permissionHours)
        {
            TotalWorkDays = totalWorkDays;
            TotalWorkHours = totalWorkHours;
            VacationDays = vacationDays;
            DiseaseDays = diseaseDays;
            Overtime = overtime;
            PermissionHours = permissionHours;
        }

        public int TotalWorkDays { get; set; }
        public int TotalWorkHours { get; set; }
        public int VacationDays { get; set; }
        public int DiseaseDays { get; set; }
        public int Overtime { get; set; }
        public int PermissionHours { get; set; }
    }
}
