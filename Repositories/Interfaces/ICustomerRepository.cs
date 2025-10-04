using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByUsernameAsync(string username);
        Task<Customer?> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task SaveChangesAsync();
    }
}
