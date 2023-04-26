using Microsoft.AspNetCore.Mvc;
using MyHome.Data;

namespace MyHome.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyData _propertyData;

        public PropertyController(IPropertyData propertyData)
        {
            _propertyData = propertyData;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var properties = await _propertyData.GetAll();
            if (properties.Any()) { 
                return Ok(properties); 
            }
            return NotFound();
        }
    }
}