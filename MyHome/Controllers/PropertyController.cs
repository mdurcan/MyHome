using Microsoft.AspNetCore.Mvc;
using MyHome.Core.Models;
using MyHome.Data;
using Microsoft.AspNetCore.JsonPatch;

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
        public IActionResult Get()
        {
            var properties = _propertyData.GetAll();
            if (properties.Any()) { 
                return Ok(properties); 
            }
            return NotFound();
        }

        [HttpGet("{propertyId}")]
        public IActionResult Get(int propertyId)
        {
            var property = _propertyData.GetById(propertyId);
            if (property != null)
            {
                return Ok(property);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Property property)
        {
            if (property == null)
                return BadRequest("Missing Property");

            var propertyToReturn = _propertyData.Add(property);
            if (propertyToReturn != null)
            {
                return Created($"Get/{propertyToReturn.PropertyId}", propertyToReturn);
            }
            return BadRequest("Property with same propertyId already excists");
        }

        [HttpPatch("{propertyId}")]
        public IActionResult Patch(int propertyId, [FromBody]JsonPatchDocument<Property> fields)
        {
            if (fields == null)
                return BadRequest("Missing Fields");

            var property = _propertyData.Update(propertyId, fields);
            if (property != null)
            {
                return Ok(property);
            }
            return NotFound();
        }

        [HttpDelete("{propertyId}")]
        public IActionResult Delete(int propertyId)
        {
            var property =  _propertyData.Delete(propertyId);
            if (property != null)
                return Ok();
            return NotFound();
        }

    }
}