namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync();
    }
}
