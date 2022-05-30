using AutoMapper;
using NBAPlayerStatistics.API.DataModels;
using NBAPlayerStatistics.API.DomainModels;

namespace NBAPlayerStatistics.API.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<Player, PlayerModel>().ReverseMap();
            this.CreateMap<Club, ClubModel>().ReverseMap();
            this.CreateMap<Position, PositionModel>().ReverseMap();
        }
    }
}
