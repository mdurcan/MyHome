using Microsoft.AspNetCore.Mvc;
using MyHome.Core.Models;
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

        [HttpGet("{propertyId}")]
        public async Task<IActionResult> Get(int propertyId)
        {
            var property = await _propertyData.GetById(propertyId);
            if (property != null)
            {
                return Ok(property);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Property property)
        {
            throw new NotImplementedException();
        }
    }
}