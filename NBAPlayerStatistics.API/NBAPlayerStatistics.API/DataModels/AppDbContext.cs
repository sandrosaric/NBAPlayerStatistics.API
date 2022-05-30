using Microsoft.EntityFrameworkCore;

namespace NBAPlayerStatistics.API.DataModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Club>().HasData(new Club
            {
                Id = Guid.Parse("c24d9ff8-9189-47ad-a5dc-7137d3ee80a2"),
                Name = "Milwaukee Bucks",
                City = "Milwaukee",
                Country = "Wisconsin"
            }, new Club
            {
                Id = Guid.Parse("69fccd0b-d925-44e6-9b87-ba5ad8d8e935"),
                Name = "Dallas Mavericks",
                City = "Dallas",
                Country = "Texas"
            },
            new Club
            {
                Id = Guid.Parse("3175d968-4fb2-4931-a31c-e1bced291985"),
                Name = "Denver Nuggets",
                City = "Denver",
                Country = "Colorado"
            },
            new Club
            {
                Id = Guid.Parse("b3f17f8a-d2c7-4be3-b230-7d42273adb45"),
                Name = "Memphis Grizzlies",
                City = "Memphis",
                Country = "Tennessee"
            },
            new Club
            {
                Id = Guid.Parse("7eef44f0-599d-40b3-8f74-78372d227480"),
                Name = "Boston Celtis",
                City = "Boston",
                Country = "Massachusetts"
            });

            /*
           
             
                use [NBAPlayerStatisticsDb];
                go

                insert into dbo.Clubs([Id],[Name],[Country],[City])
                values('c24d9ff8-9189-47ad-a5dc-7137d3ee80a2','Milwaukee Bucks' ,'Wisconsin','Milwaukee'),
	                ('69fccd0b-d925-44e6-9b87-ba5ad8d8e935','Dallas Mavericks' ,'Texas','Dallas'),
	                ('3175d968-4fb2-4931-a31c-e1bced291985','Denver Nuggets' ,'Colorado','Denver'),
	                ('b3f17f8a-d2c7-4be3-b230-7d42273adb45','Memphis Grizzlies' ,'Tennessee','Memphis'),
	                ('7eef44f0-599d-40b3-8f74-78372d227480','Boston Celtis' ,'Massachusetts','Boston')
	                go


                insert into dbo.Positions([Id],[Name])
                values('76858f76-39ff-4df4-af86-d83c39338d16','Point Guard'),
                ('774b8b2b-840f-400d-951f-44f14719fb97','Shooting Guard'),
                ('8c7f8b85-045f-4c53-80c9-f5faa844e3e5','Small Forward'),
                ('108b4d4f-d843-4628-9998-bfe48129f16b','Power Forward'),
                ('c981f57d-ffa9-419c-b51d-c47d47665814','Center')
                go

                insert into dbo.Players([Id],[FirstName],[LastName],[PositionId],[ClubId],[ProfileImageUrl],[DateOfBirth],[PTS],[REB],[AST],[PER])
                values('1f12e8f2-8438-48b6-b554-bdf2e922bde3','Giannis','Antnetokoumpo','108b4d4f-d843-4628-9998-bfe48129f16b','c24d9ff8-9189-47ad-a5dc-7137d3ee80a2',NULL,'12-6-1994',29.9,11.6,5.8,32.12),
	                ('2f971a05-c320-4db2-8ea6-9a409a7455ff','Luka','Doncic','76858f76-39ff-4df4-af86-d83c39338d16','69fccd0b-d925-44e6-9b87-ba5ad8d8e935',NULL,'2-28-1999', 28.4,9.1,8.7,25.13),
	                ('acbdfb01-ac96-466b-bf09-b96bbbda34b8','Nikola','Jokic','c981f57d-ffa9-419c-b51d-c47d47665814','3175d968-4fb2-4931-a31c-e1bced291985',NULL,'2-19-1995', 27.1,13.8, 7.9,32.94),
	                ('1628e759-dfae-4fab-bbc6-f6a3bab83b4a','Ja','Morant','76858f76-39ff-4df4-af86-d83c39338d16','b3f17f8a-d2c7-4be3-b230-7d42273adb45',NULL,'8-10-1999', 27.4,5.7, 6.7,24.53),
	                ('37c02636-4483-49af-b5c3-90c680bb5b20','Jayson','Tatum','8c7f8b85-045f-4c53-80c9-f5faa844e3e5','7eef44f0-599d-40b3-8f74-78372d227480',NULL,'3-3-1998', 26.9,8.0, 4.4,4.4)



                go

                        */

        }
    }

}