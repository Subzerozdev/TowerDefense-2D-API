
using Microsoft.EntityFrameworkCore;
using Repositories.Data;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class WaveRepository : IWaveRepository
    {
        private readonly ApplicationDbContext _context;
        public WaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Wave?> GetByIdAsync(int id)
        {
            return await _context.Waves
                .Include(w => w.Gamelevel)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
