
using Repositories.Entities;
using Repositories.Interfaces;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Implements
{
    public class GameLevelService : IGameLevelService
    {
        private readonly IGameLevelRepository _repo;
        public GameLevelService(IGameLevelRepository repo)
        {
            _repo = repo;
        }

        public async Task<Gamelevel?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity;
        }

        public async Task<GameLevelDto?> GetLevelByLevelAsync(int level)
        {
            var entity = await _repo.GetByLevelAsync(level);
            return entity == null ? null : Map(entity);
        }

        public async Task<List<GameLevelDto>> GetLevelByWaveLevelAsync(int waveLevel)
        {
            var list = await _repo.GetByWaveLevelAsync(waveLevel);
            return list.Select(Map).ToList();
        }

        private GameLevelDto Map(Repositories.Entities.Gamelevel g)
        {
            return new GameLevelDto
            {
                Id = g.Id,
                Level = g.Level,
                Coin = g.Coin,
                Heart = g.Heart,
                Waves = g.Waves.OrderBy(w => w.Wavelevel).Select(w => new WaveDto
                {
                    Id = w.Id,
                    WaveLevel = w.Wavelevel,
                    TotalEnemy = w.Totalenemy,
                    Spawnpoints = w.Spawnpoints.Select(sp => new SpawnPointDto
                    {
                        Id = sp.Id,
                        DelayAtFirstTime = sp.Delayatfirsttime,
                        DelayEachSpawn = sp.Delayeachspawn,
                        Spawns = sp.Spawns.OrderBy(s => s.Priority).Select(s => new SpawnDto
                        {
                            Id = s.Id,
                            EnemyNumber = s.Enemynumber,
                            EnemyType = s.Enemytype,
                            Priority = s.Priority
                        }).ToList()
                    }).ToList()
                }).ToList()
            };
        }
    }
}
