
using Services.DTOs;
namespace Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto?> RegisterAsync(string username, string password);
        Task<CustomerDto?> LoginAsync(string username, string password);
        Task<IEnumerable<(string Username, double Point)>> GetListPointAsync();
    }
}
