namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player> GetPlayerByIdAsync(Guid playerId);
        Task<Player> UpdatePlayerAsync(Guid playerId,Player player);
        Task<bool> ExistsAsync(Guid playerId);
        Task<Player> DeletePlayerAsync(Guid playerId);
        Task<Player> CreatePlayerAsync(Player player);

    }
}
