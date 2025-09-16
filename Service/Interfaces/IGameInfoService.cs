using Repository.Model;


namespace Service.Interfaces
{
    public interface IGameInfoService
    {
        Task<IEnumerable<GameInfo>> GetAllAsync();
        Task<GameInfo> GetByIdAsync(string id);
        Task CreateAsync(GameInfo gameInfo);
        Task UpdateAsync(GameInfo gameInfo);
        Task DeleteAsync(string id);
    }
}
