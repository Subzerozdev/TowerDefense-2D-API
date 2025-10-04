
using Microsoft.EntityFrameworkCore;
using Repositories.Data;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class GameProgressRepository : IGameProgressRepository
    {
        private readonly ApplicationDbContext _context;
        public GameProgressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Gameprogress?> GetByCustomerIdAsync(int customerId) =>
            await _context.Gameprogresses.FirstOrDefaultAsync(g => g.CustomerId == customerId);

        public async Task UpdateAsync(Gameprogress progress)
        {
            _context.Gameprogresses.Update(progress);
            await _context.SaveChangesAsync();
        }
    }
}
