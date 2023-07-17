using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace TestMillionAndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTraceController : ControllerBase
    {
        private readonly IPropertyTraceService _propertyTraceService;
        public PropertyTraceController(IPropertyTraceService propertyTraceService)
        {
            _propertyTraceService = propertyTraceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyTraceDto propertyTraceDto)
        {
            bool created = await _propertyTraceService.Create(propertyTraceDto);

            if (created)
                return StatusCode(201, new { Message = "Property Trace created successfully." });
            else
                return StatusCode(500, new { Message = "Failed to create Property Trace." });
        }
    }
}
