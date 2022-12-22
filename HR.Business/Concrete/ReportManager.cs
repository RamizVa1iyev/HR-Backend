using Core.Extensions;
using HR.Business.Abstract;
using HR.Entities.Models.Other;
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

        public ReportManager(IEmployeeService employeeService, ICalendarDayService calendarDayService, IDiseaseBulletenService diseaseBulletenService, IDutyService dutyService, IOvertimeService overtimeService, IPermissionService permissionService, IStateService stateService, IVacationService vacationService, INotificationService notificationService)
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
                        item.Permissions.Where(p=>p.PermissionType == Entities.Constants.PermissionTypes.Hour).Select(p=>p.Count).Sum()
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
    }
}
