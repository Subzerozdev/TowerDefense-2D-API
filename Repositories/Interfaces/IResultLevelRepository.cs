using Repositories.Entities;
namespace Repositories.Interfaces
{
    public interface IResultLevelRepository
    {
        Task<Resultlevel> AddAsync(Resultlevel result);
        Task UpdateAsync(Resultlevel resultlevel);
        Task<Resultlevel?> GetByCustomerAndLevelAsync(int customerId, int gameLevelId);
        Task SaveChangesAsync();
    }
}
