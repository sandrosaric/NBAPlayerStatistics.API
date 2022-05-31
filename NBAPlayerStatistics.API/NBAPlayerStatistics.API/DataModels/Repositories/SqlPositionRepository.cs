using Microsoft.EntityFrameworkCore;

namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public class SqlPositionRepository : IPositionRepository
    {
        private readonly AppDbContext _context;

        public SqlPositionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Position>> GetAllPositionsAsync()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
