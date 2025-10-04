using Repositories.Entities;
using Services.DTOs;


namespace Services.Interfaces
{
    public interface IGameLevelService
    {
        Task<GameLevelDto?> GetLevelByLevelAsync(int level);
        Task<List<GameLevelDto>> GetLevelByWaveLevelAsync(int waveLevel);
        Task<Gamelevel?> GetByIdAsync(int id);
    }
}
