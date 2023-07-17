using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace TestMillionAndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageService _propertyimageService;
        public PropertyImageController(IPropertyImageService propertyImageService)
        {
            _propertyimageService = propertyImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyImageDto propertyImageDto)
        {
            bool created = await _propertyimageService.Create(propertyImageDto);

            if (created)
                return StatusCode(201, new { Message = "Property Image created successfully." });
            else
                return StatusCode(500, new { Message = "Failed to create Property Image." });
        }
    }
}
