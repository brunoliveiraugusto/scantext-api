using Microsoft.AspNetCore.Mvc;
using ScanText.Domain.Utils.Interfaces;
using System.Linq;

namespace ScanText.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public BaseController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        protected IActionResult ResponseRequest(object result = null)
        {
            if(ValidRequest())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificationService.Notifications.Select(notification => new { notification.Chave, notification.Valor })
            });
        }

        protected bool ValidRequest()
        {
            return !_notificationService.Notifications.Any();
        }
    }
}
