

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

            progress.Currentcoin = dto.CurrentCoin;
            progress.Currentheart = dto.CurrentHeart;
            progress.Currentpoint = dto.CurrentPoint;
            progress.WaveId = dto.WaveId;

            await _progressRepo.UpdateAsync(progress);

            return new GameProgressDto
            {
                Id = progress.Id,
                CurrentCoin = progress.Currentcoin,
                CurrentHeart = progress.Currentheart,
                CurrentPoint = progress.Currentpoint,
                WaveId = progress.WaveId
            };
        }
    }
}
