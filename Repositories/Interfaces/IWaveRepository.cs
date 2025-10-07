using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IWaveRepository
    {
        Task<Wave?> GetByIdAsync(int id);
    }
}
