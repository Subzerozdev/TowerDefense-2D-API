using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Repositories.Data;
using Repositories.Entities;
using Repositories.Interfaces;


namespace Repositories.Implements
{
    public class GameLevelRepository : IGameLevelRepository
    {
        private readonly ApplicationDbContext _context;
        public GameLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Gamelevel?> GetByIdAsync(int id)
        {
            return await _context.Gamelevels
                .Include(g => g.Waves)
                    .ThenInclude(w => w.Spawnpoints)
                        .ThenInclude(sp => sp.Spawns)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Gamelevel?> GetByLevelAsync(int level) =>
            await _context.Gamelevels
                .Include(g => g.Waves)
                    .ThenInclude(w => w.Spawnpoints)
                        .ThenInclude(sp => sp.Spawns)
                .FirstOrDefaultAsync(g => g.Level == level);
    }
}

