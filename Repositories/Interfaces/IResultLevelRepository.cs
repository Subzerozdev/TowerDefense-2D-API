using Repositories.Entities;
namespace Repositories.Interfaces
{
    public interface IResultLevelRepository
    {
        Task<Resultlevel> AddAsync(Resultlevel result);
        Task SaveChangesAsync();
    }
}
