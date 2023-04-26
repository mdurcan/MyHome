using Microsoft.AspNetCore.Mvc;

namespace MyHome.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return null;
        }
    }
}