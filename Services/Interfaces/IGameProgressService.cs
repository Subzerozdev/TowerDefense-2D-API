using Services.DTOs;
namespace Services.Interfaces
{
    public interface IGameProgressService
    {
        Task<GameProgressDto?> UpdateGameProgressAsync(UpdateGameProgressDto dto);
    }
}
