using Repositories.Entities;
namespace Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory?> GetByCustomerIdAsync(int customerId);
        Task UpdateAsync(Inventory inventory);
    }
}
