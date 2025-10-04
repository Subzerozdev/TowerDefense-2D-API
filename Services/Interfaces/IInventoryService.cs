using Services.DTOs;

namespace Services.Interfaces
{
    public interface IInventoryService
    {
        Task<UpdateInventoryResponseDto?> UpdateInventoryAsync(UpdateInventoryDto dto);
    }
}
