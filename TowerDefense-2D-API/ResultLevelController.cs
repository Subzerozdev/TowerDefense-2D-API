
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace TowerDefense_2D_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultLevelController : ControllerBase
    {
        private readonly IResultLevelService _service;

        public ResultLevelController(IResultLevelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResultLevel(CreateResultLevelDto dto)
        {
            var result = await _service.CreateResultLevelAsync(dto);
            return Ok(result);
        }
    }
}
