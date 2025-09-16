using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Model;

namespace Repository.Implements
{
    public class GameInfoRepository : IGameInfoRepository
    {
        private readonly AppDbContext _context;

        public GameInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameInfo>> GetAllAsync()
        {
            return await _context.GameInfos
                                 .Include(g => g.Customer)
                                 .ToListAsync();
        }

        public async Task<GameInfo> GetByIdAsync(string id)
        {
            return await _context.GameInfos
                                 .Include(g => g.Customer)
                                 .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddAsync(GameInfo gameInfo)
        {
            await _context.GameInfos.AddAsync(gameInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameInfo gameInfo)
        {
            _context.GameInfos.Update(gameInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var gameInfo = await _context.GameInfos.FindAsync(id);
            if (gameInfo != null)
            {
                _context.GameInfos.Remove(gameInfo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
