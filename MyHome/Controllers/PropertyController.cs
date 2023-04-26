using Microsoft.AspNetCore.Mvc;
using MyHome.Core.Services;

namespace MyHome.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var properties = await _propertyService.GetAll();
            if (properties.Any()) { 
                return Ok(properties); 
            }
            return NotFound();
        }
    }
}