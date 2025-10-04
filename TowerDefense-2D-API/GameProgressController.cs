using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace TowerDefense_2D_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameProgressController : ControllerBase
    {
        private readonly IGameProgressService _service;

        public GameProgressController(IGameProgressService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGameProgress(UpdateGameProgressDto dto)
        {
            var result = await _service.UpdateGameProgressAsync(dto);
            if (result == null) return NotFound("Game progress not found for this customer");

            return Ok(result);
        }
    }
}
