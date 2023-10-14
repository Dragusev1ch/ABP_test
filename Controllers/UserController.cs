using ABP_test.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABP_test.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("button-color")]
        public IActionResult GetButtonColorExperiment([FromQuery] string deviceToken)
        {
            string key = "button_color";
            string value = _userService.GetExperimentValue(deviceToken, key);

            if (value == null)
            {
                return NotFound("Device token not found.");
            }

            return Ok(new { key, value });
        }

        [HttpGet("price")]
        public IActionResult GetPriceExperiment([FromQuery] string deviceToken)
        {
            string key = "price";
            string value = _userService.GetExperimentValue(deviceToken, key);

            if (value == null)
            {
                return NotFound("Device token not found.");
            }

            return Ok(new { key, value });
        }
    }
}
