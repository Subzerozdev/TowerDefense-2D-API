using Repositories.Entities;
namespace Repositories.Interfaces
{
    public interface IGameLevelRepository
    {
        Task<Gamelevel?> GetByLevelAsync(int level);
        Task<Gamelevel?> GetByIdAsync(int id);
    }
}
