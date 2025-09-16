using Repository.Model;

namespace Repository.Interfaces
{
    public interface IGameInfoRepository
    {
        Task<IEnumerable<GameInfo>> GetAllAsync();
        Task<GameInfo> GetByIdAsync(string id);
        Task AddAsync(GameInfo gameInfo);
        Task UpdateAsync(GameInfo gameInfo);
        Task DeleteAsync(string id);
    }
}
