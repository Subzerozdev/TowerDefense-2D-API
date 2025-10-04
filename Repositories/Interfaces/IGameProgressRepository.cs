using Repositories.Entities;
namespace Repositories.Interfaces
{
    public interface IGameProgressRepository
    {
        Task<Gameprogress?> GetByCustomerIdAsync(int customerId);
        Task UpdateAsync(Gameprogress progress);
    }
}
