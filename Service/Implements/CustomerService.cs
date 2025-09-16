using Repository.Interfaces;
using Repository.Model;
using Service.Interfaces;

namespace Service.Implements
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
