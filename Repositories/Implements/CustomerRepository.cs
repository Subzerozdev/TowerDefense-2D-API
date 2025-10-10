using Microsoft.EntityFrameworkCore;
using Repositories.Data;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByUsernameAsync(string username)
        {
            return await _context.Customers
                .Include(c => c.Inventory)
                .Include(c => c.Gameprogress).ThenInclude(g => g.Towerplaces)
                .Include(c => c.Resultlevels)
                .FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            // 1. Tải Customer và các mối quan hệ 1-1
            var customer = await _context.Customers
                .Include(c => c.Inventory)
                .Include(c => c.Resultlevels)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return null;
            }

            // 2. Tải và Sắp xếp riêng GameProgress và Towerplaces
            // Vì GameProgress là quan hệ 1-1 (hoặc 1-0) với Customer, nên ta truy cập trực tiếp
            await _context.Entry(customer)
                .Reference(c => c.Gameprogress) 
                .Query()
                .Include(g => g.Towerplaces 
                                          
                    .OrderBy(t => t.Node)
                )
                .LoadAsync();

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
