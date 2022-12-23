using HR.Business.Abstract;
using HR.Entities.Models.Other;
using HR.Entities.Models.Other.Salary;
using HR.Entities.Models.ResponseModels;

namespace HR.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICalendarDayService _calendarDayService;
        private readonly IDiseaseBulletenService _diseaseBulletenService;
        private readonly IDutyService _dutyService;
        private readonly IOvertimeService _overtimeService;
        private readonly IPermissionService _permissionService;
        private readonly IStateService _stateService;
        private readonly IVacationService _vacationService;
        private readonly INotificationService _notificationService;
        private readonly IEmployeeRewardService _employeeRewardService;
        private readonly IRewardService _rewardService;

        public ReportManager(IEmployeeService employeeService, ICalendarDayService calendarDayService, IDiseaseBulletenService diseaseBulletenService, IDutyService dutyService, IOvertimeService overtimeService, IPermissionService permissionService, IStateService stateService, IVacationService vacationService, INotificationService notificationService, IEmployeeRewardService employeeRewardService, IRewardService rewardService)
        {
            _employeeService = employeeService;
            _calendarDayService = calendarDayService;
            _diseaseBulletenService = diseaseBulletenService;
            _dutyService = dutyService;
            _overtimeService = overtimeService;
            _permissionService = permissionService;
            _stateService = stateService;
            _vacationService = vacationService;
            _notificationService = notificationService;
            _employeeRewardService = employeeRewardService;
            _rewardService = rewardService;
        }

        public SalaryResponseModel GetSalary(DateTime date)
        {
            var ds = new SalaryDataStructure();
            ds.ForDate = date;

            var data = new List<SalaryRow>();

            var mainData = _employeeService.GetEmployeeMainData(date);
            var tabel = GetTabel(date);

            foreach (var item in tabel.Rows)
            {
                var d = mainData.First(e => e.Name == item.Name & e.Surname == item.Surname & e.FatherName == item.FatherName);
                var totalWorkHours = item.TotalWorkDays * d.DailyWorkHour;
                var computedSalary = (item.Salary / ((item.TotalWorkDays == 0 ? 1 : item.TotalWorkDays) * (d.DailyWorkHour == 0 ? 1 : d.DailyWorkHour))) * item.TotalWorkHours;
                var reward = ComputeReward(d.EmployeeId);
                var sumSalary = computedSalary + reward;
                var incomingTax = GetIncomingTax(sumSalary);
                var pensionFond = GetPensionFond(sumSalary);
                var ish = GetIsh(sumSalary);
                var itsh = GetItsh(sumSalary);
                var totalTax = incomingTax + pensionFond + ish + itsh;
                var valueToPaid = sumSalary - totalTax;
                var row = new SalaryRow
                    (
                        item.No, item.Name, item.Surname, item.FatherName, item.Duty, item.Salary, totalWorkHours,
                        item.TotalWorkHours, computedSalary, reward, 0, sumSalary, incomingTax, pensionFond, ish, itsh, totalTax, valueToPaid
                    );
                data.Add(row);
            }

            ds.AddRange(data);

            return ds.Export();
        }

        private decimal GetIncomingTax(decimal sumSalary)
        {
            if (sumSalary <= 8000)
                return 0;

            return (sumSalary - 8000) * 0.14m;
        }

        private decimal GetPensionFond(decimal sumSalary)
        {
            if (sumSalary <= 200)
                return sumSalary * 0.03m;
            return 6 + (sumSalary - 200) * 0.1m;
        }

        private decimal GetIsh(decimal sumSalary)
        {
            return sumSalary * 0.05m;
        }

        private decimal GetItsh(decimal sumSalary)
        {
            if (sumSalary <= 8000)
                return sumSalary * 0.01m;

            return 80 + (sumSalary - 8000) * 0.05m;
        }

        private decimal ComputeReward(int employeeId)
        {
            var empRewards = _employeeRewardService.GetEmployeeRewardByEmployee(employeeId);
            var rewards = _rewardService.GetAll();

            var result = from e in empRewards
                         join r in rewards on e.RewardId equals r.Id
                         select new RewardModel
                         {
                             RewardId = e.RewardId,
                             Value = r.Amount
                         };

            return result.Select(r => r.Value).Sum();
        }

        public TabelResponseModel GetTabel(DateTime date)
        {
            var ds = new TabelDataStructure();
            ds.ForDate = date;

            var data = new List<TabelRow>();

            var mainData = _employeeService.GetEmployeeMainData(date);

            foreach (var item in mainData)
            {
                var row = new TabelRow
                    (
                        new TabelMainData(item.No, item.EmployeeId, item.Name, item.Surname, item.FatherName, item.Salary, item.Duty, item.State),
                        new TabelValues(),
                        item.Overtimes.Select(o => o.HourCount).Count(),
                        item.Permissions.Where(p => p.PermissionType == Entities.Constants.PermissionTypes.Hour).Select(p => p.Count).Sum()
                    );
                row.Values.SetAll(item.DailyWorkHour.ToString());

                data.Add(row);
            }

            ds.AddRange(data);

            ds.Prepare(_calendarDayService.GetByDate(date).OrderBy(c => c.Date).ToList(), mainData);

            return ds.Export();
        }

        protected TTarget Map<TCurrent, TTarget>(TCurrent source)
        {
            var data = Activator.CreateInstance<TTarget>();

            var targetProperties = source.GetType().GetProperties();
            var destinationProperties = data.GetType().GetProperties();

            foreach (var dp in destinationProperties)
            {
                var val = targetProperties.FirstOrDefault(p => p.Name == dp.Name)?.GetValue(source);
                dp.SetValue(data, val);
            }

            return data;
        }

        class RewardModel
        {
            public int RewardId { get; set; }
            public decimal Value { get; set; }
        }
    }
}
