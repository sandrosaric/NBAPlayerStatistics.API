using Microsoft.EntityFrameworkCore;

namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public SqlPlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllAsync()
        {
           return   await _context.Players.Include(nameof(Club)).Include(nameof(Position)).ToListAsync();
        }
    }
    }

