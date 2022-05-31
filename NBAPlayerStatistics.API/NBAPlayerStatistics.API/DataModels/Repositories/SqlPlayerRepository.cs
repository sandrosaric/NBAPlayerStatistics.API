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

        public async Task<bool> ExistsAsync(Guid playerId)
        {
            return await _context.Players.AnyAsync(x => x.Id == playerId);  
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
           return   await _context.Players.Include(nameof(Club)).Include(nameof(Position)).ToListAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(Guid playerId)
        {
            var player = await _context.Players.Include(nameof(Club)).Include(nameof(Position)).FirstOrDefaultAsync(x => x.Id == playerId);
            return player;
        }

        public async Task<Player> UpdatePlayerAsync(Guid playerId, Player player)
        {
           var playerDb = await GetPlayerByIdAsync(playerId);
            if(playerDb != null)
            {
                playerDb.FirstName = player.FirstName;
                playerDb.LastName = player.LastName;
                playerDb.DateOfBirth = player.DateOfBirth;
                playerDb.PositionId = player.PositionId;
                playerDb.ClubId = player.ClubId;
                playerDb.PER = player.PER;
                playerDb.AST = player.AST;
                playerDb.REB = player.REB;
                playerDb.PTS = player.PTS;
                await _context.SaveChangesAsync();
                return playerDb;
            }


            return null;

        }
    }
    }

