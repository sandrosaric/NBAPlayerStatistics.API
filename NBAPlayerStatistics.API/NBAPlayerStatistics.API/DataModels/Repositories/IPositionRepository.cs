namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetAllPositionsAsync();
    }
}
