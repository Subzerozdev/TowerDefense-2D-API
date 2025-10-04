using Repositories.Entities;
namespace Repositories.Interfaces
{
    public interface IGameLevelRepository
    {
        Task<Gamelevel?> GetByLevelAsync(int level);
        Task<List<Gamelevel>> GetByWaveLevelAsync(int waveLevel);
        Task<Gamelevel?> GetByIdAsync(int id);
    }
}
