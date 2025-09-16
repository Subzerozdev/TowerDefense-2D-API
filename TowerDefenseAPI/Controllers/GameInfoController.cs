using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using TowerDefenseAPI.DTO;

namespace TowerDefenseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameInfoController : ControllerBase
    {
        private readonly IGameInfoService _gameInfoService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public GameInfoController(
            IGameInfoService gameInfoService,
            ICustomerService customerService,
            IMapper mapper)
        {
            _gameInfoService = gameInfoService;
            _customerService = customerService;
            _mapper = mapper;
        }

        // GetPlayerGameInfo(string userId)
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPlayerGameInfo(string userId)
        {
            var gameInfo = await _gameInfoService.GetByIdAsync(userId);
            if (gameInfo == null) return NotFound();

            return Ok(_mapper.Map<GameInfoReadDto>(gameInfo));
        }

        // GetAllPlayerGameInfos()
        [HttpGet]
        public async Task<IActionResult> GetAllPlayerGameInfos()
        {
            var gameInfos = await _gameInfoService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GameInfoReadDto>>(gameInfos));
        }

        // UpdateGameInfo(string userId, GameInfoUpdateDto dto)
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateGameInfo(string userId, [FromBody] GameInfoUpdateDto dto)
        {
            var gameInfo = await _gameInfoService.GetByIdAsync(userId);
            if (gameInfo == null) return NotFound();

            // update fields
            _mapper.Map(dto, gameInfo);

            await _gameInfoService.UpdateAsync(gameInfo);

            return Ok(_mapper.Map<GameInfoReadDto>(gameInfo));
        }
    }
}
