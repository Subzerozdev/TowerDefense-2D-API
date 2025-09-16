using Repository.Interfaces;
using Repository.Model;
using Service.Interfaces;

namespace Service.Implements
{
    public class GameInfoService : IGameInfoService
    {
        private readonly IGameInfoRepository _gameInfoRepository;

        public GameInfoService(IGameInfoRepository gameInfoRepository)
        {
            _gameInfoRepository = gameInfoRepository;
        }

        public async Task<IEnumerable<GameInfo>> GetAllAsync()
        {
            return await _gameInfoRepository.GetAllAsync();
        }

        public async Task<GameInfo> GetByIdAsync(string id)
        {
            return await _gameInfoRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(GameInfo gameInfo)
        {
            await _gameInfoRepository.AddAsync(gameInfo);
        }

        public async Task UpdateAsync(GameInfo gameInfo)
        {
            await _gameInfoRepository.UpdateAsync(gameInfo);
        }

        public async Task DeleteAsync(string id)
        {
            await _gameInfoRepository.DeleteAsync(id);
        }
    }
}
