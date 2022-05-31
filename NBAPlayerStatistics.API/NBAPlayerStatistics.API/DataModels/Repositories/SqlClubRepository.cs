using Microsoft.EntityFrameworkCore;

namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public class SqlClubRepository : IClubRepository
    {
        private readonly AppDbContext _context;

        public SqlClubRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Club>> GetAllClubsAsync()
        {
            return await _context.Clubs.ToListAsync();
        }
    }
}
