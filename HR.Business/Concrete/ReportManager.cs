using HR.Business.Abstract;
using HR.Entities.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IEmployeeService _employeeService;
        public ReportManager()
        {

        }

        public TabelResponseModel GetTabel(DateTime date)
        {
            throw new NotImplementedException();
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
