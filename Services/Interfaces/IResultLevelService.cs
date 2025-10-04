

using Services.DTOs;

namespace Services.Interfaces
{
    public interface IResultLevelService
    {
        Task<ResultLevelDto> CreateResultLevelAsync(CreateResultLevelDto dto);
    }
}
