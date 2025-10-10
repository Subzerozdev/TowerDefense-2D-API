

using Repositories.Entities;
using Repositories.Interfaces;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Implements
{
    public class GameProgressService : IGameProgressService
    {
        private readonly IGameProgressRepository _progressRepo;

        public GameProgressService(IGameProgressRepository progressRepo)
        {
            _progressRepo = progressRepo;
        }

        public async Task<GameProgressDto?> UpdateGameProgressAsync(UpdateGameProgressDto dto)
        {
            var progress = await _progressRepo.GetByCustomerIdAsync(dto.CustomerId);
            if (progress == null) return null;

            List<Towerplace> newTowerplaces = [.. dto.Towerplaces
                    .Select(tpDto => new Towerplace
                    {
                        Node = tpDto.Node,
                        TowerType = tpDto.TowerType
                    })];

            progress.Currentcoin = dto.CurrentCoin;
            progress.Currentheart = dto.CurrentHeart;
            progress.Currentpoint = dto.CurrentPoint;


            if (dto.WaveId == 0)
            {
                progress.Wave = null;
            }
            else
            {
                progress.WaveId = dto.WaveId;
            }

            progress.Towerplaces.Clear();

            foreach (var towerplace in newTowerplaces)
            {
                progress.Towerplaces.Add(towerplace);
            }

            await _progressRepo.UpdateAsync(progress);

            return new GameProgressDto
            {
                Id = progress.Id,
                CurrentCoin = progress.Currentcoin,
                CurrentHeart = progress.Currentheart,
                CurrentPoint = progress.Currentpoint,
                WaveId = progress.WaveId,
                Towerplaces = (List<Towerplace>)progress.Towerplaces
            };
        }
    }
}
