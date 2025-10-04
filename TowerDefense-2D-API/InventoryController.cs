using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace TowerDefense_2D_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInventory(UpdateInventoryDto dto)
        {
            var result = await _service.UpdateInventoryAsync(dto);
            if (result == null) return NotFound("Inventory not found for this customer");

            return Ok(result);
        }
    }
}
