using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TowerDefense_2D_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameLevelController : ControllerBase
    {
        private readonly IGameLevelService _service;

        public GameLevelController(IGameLevelService service)
        {
            _service = service;
        }

        [HttpGet("{level}")]
        public async Task<IActionResult> GetLevelByLevel(int level)
        {
            var dto = await _service.GetLevelByLevelAsync(level);
            if (dto == null) return NotFound();

            return Ok(dto);
        }

        [HttpGet("wave/{waveLevel}")]
        public async Task<IActionResult> GetLevelByWaveLevel(int waveLevel)
        {
            var dto = await _service.GetLevelByWaveLevelAsync(waveLevel);
            return Ok(dto != null ? dto.Level : 0);
        }
    }
}
