
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

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
