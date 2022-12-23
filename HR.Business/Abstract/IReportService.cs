using HR.Entities.Models.ResponseModels;

namespace HR.Business.Abstract
{
    public interface IReportService
    {
        TabelResponseModel GetTabel(DateTime date);
        SalaryResponseModel GetSalary(DateTime date);
    }
}
