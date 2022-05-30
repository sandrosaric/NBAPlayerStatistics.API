namespace NBAPlayerStatistics.API.DomainModels
{
    public class ClubModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
