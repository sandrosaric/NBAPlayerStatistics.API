namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAllClubsAsync();
    }
}
