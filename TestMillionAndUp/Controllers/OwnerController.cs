using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace TestMillionAndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerDto ownerDto)
        {
            bool created = await _ownerService.CreateOwner(ownerDto);

            if (created)
                return StatusCode(201, new { Message = "Owner created successfully." });
            else
                return StatusCode(500, new { Message = "Failed to create owner." });
        }
    }
}
