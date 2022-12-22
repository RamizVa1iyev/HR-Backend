using HR.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IEmployeeService _employeeService;

        public ReportsController(IReportService reportService, IEmployeeService employeeService)
        {
            _reportService = reportService;
            _employeeService = employeeService;
        }

        [HttpGet("test")]
        public IActionResult Test(DateTime date)
        {
            return Ok(_employeeService.GetEmployeeMainData(date));
        }

        [HttpGet("tabel")]
        public IActionResult Tabel(DateTime date) 
        {
            return Ok(_reportService.GetTabel(date));
        }
    }
}
