using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace TestMillionAndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyDto propertyDto)
        {
            int idProperty = await _propertyService.CreateProperty(propertyDto);

            if (idProperty == 0)
                return StatusCode(500, new { Message = "Failed to create Property." });
            else
                return StatusCode(201, new { Message = "Property created successfully." });

        }

        [HttpPut("{propertyId}/ChangePrice")]
        public async Task<IActionResult> ChangePropertyPrice(int propertyId, [FromBody] decimal newPrice)
        {
            try
            {
                bool priceChanged = await _propertyService.ChangePrice(propertyId, newPrice);
                if (priceChanged)
                    return Ok(new { Success = true, Message = "Property price changed successfully." });
                else
                    return BadRequest(new { Success = false, Message = "Failed to change property price. Property not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred while changing the property price.", Error = ex.Message });
            }
        }

        [HttpPut("{propertyId}")]
        public async Task<IActionResult> UpdateProperty(int propertyId, PropertyDto updatedProperty)
        {
            var success = await _propertyService.UpdateProperty(propertyId, updatedProperty);
            if (success)
                return Ok();
            
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties(string? nameFilter, decimal? minPrice, decimal? maxPrice, int? year)
        {
            var properties = await _propertyService.GetProperties(nameFilter, minPrice, maxPrice, year);
            return Ok(properties);
        }
    }
}
