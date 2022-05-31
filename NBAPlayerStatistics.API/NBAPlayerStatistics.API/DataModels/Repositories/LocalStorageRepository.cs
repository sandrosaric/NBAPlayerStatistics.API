namespace NBAPlayerStatistics.API.DataModels.Repositories
{
    public class LocalStorageRepository : IImageRepository
    {
        public async Task<string> UploadImageAsync(IFormFile file, string fileName)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images",fileName);
            using Stream fileStream = new FileStream(filepath,FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerPath(fileName);
        }

        private string  GetServerPath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
