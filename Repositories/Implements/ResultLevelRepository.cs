
using Microsoft.EntityFrameworkCore;
using Repositories.Data;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class ResultLevelRepository : IResultLevelRepository
    {
        private readonly ApplicationDbContext _context;
        public ResultLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Resultlevel> AddAsync(Resultlevel result)
        {
            _context.Resultlevels.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(Resultlevel resultlevel)
        {
            _context.Resultlevels.Update(resultlevel);
            await _context.SaveChangesAsync();
        }

        public async Task<Resultlevel?> GetByCustomerAndLevelAsync(int customerId, int gameLevelId)
        {
            return await _context.Resultlevels
                .FirstOrDefaultAsync(r => r.CustomerId == customerId && r.GameLevelId == gameLevelId);
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
