namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadImageAsync(IFormFile file, string filename);
    }
}
