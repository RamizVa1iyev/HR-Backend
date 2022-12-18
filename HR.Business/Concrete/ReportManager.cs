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

            var data = new List<TabelRow>();

            var mainData = _employeeService.GetEmployeeMainData();

            foreach (var item in mainData)
            {
                //data.Add(new TabelRow(item, new TabelValues(), ))
            }





            ds.AddRange(data);

            return new TabelResponseModel();
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
