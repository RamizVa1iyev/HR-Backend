using Core.Entities.Concrete;
using Core.WebAPI;
using HR.Business.Abstract;
using HR.Entities.Concrete;
using HR.Entities.Constants;
using HR.Entities.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController<INotificationService, Notification, NotificationAddRequestModel, NotificationUpdateRequestModel, NotificationDeleteRequestModel>
    {
        private Dictionary<int, dynamic> nDefinitions;

        public NotificationsController(INotificationService service) : base(service)
        {

        }

        [HttpGet("notification")]
        public IActionResult GetNotificationResult(int notificationId)
        {
            var type = Service.GetNotificationType(notificationId);

            switch (type)
            {
                case Entities.Constants.NotificationTypes.Recruitment:
                    return Ok(Service.Recruitment(notificationId));
                case Entities.Constants.NotificationTypes.Disease:
                    return Ok(Service.Disease(notificationId));
                case Entities.Constants.NotificationTypes.Permission:
                    return Ok(Service.Permission(notificationId));
                case Entities.Constants.NotificationTypes.Vacation:
                    return Ok(Service.Vacation(notificationId));
                default:
                    break;
            }

            return BadRequest("Notification does not match specified types.");
        }

        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int userId)
        {
            return Ok(Service.GetByUser(userId));
        }

        [HttpPost("setstatus")]
        public IActionResult SetStatus(int notificationId, Status status)
        {
            return Ok(Service.SetStatus(notificationId, status));
        }

        [HttpPost("saveemployee")]
        public IActionResult SaveEmployee(int notificationId, EmployeeUpdateRequestModel employeeUpdateRequestModel)
        {
            return Ok(Service.SaveEmployee(notificationId, employeeUpdateRequestModel));
        }
    }
}
