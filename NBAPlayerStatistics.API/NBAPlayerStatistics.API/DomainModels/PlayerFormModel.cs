namespace NBAPlayerStatistics.API.DomainModels
{
    public class PlayerFormModel
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid PositionId { get; set; }
        public Guid ClubId { get; set; }
      
        public DateTime DateOfBirth { get; set; }

        public double PTS { get; set; }
        public double REB { get; set; }
        public double AST { get; set; }
        public double PER { get; set; }



      
    }
}
