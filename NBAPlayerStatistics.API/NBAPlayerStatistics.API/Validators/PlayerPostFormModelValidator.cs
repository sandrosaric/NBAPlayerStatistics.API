using FluentValidation;
using NBAPlayerStatistics.API.DataModels.Repositories;
using NBAPlayerStatistics.API.DomainModels;

namespace NBAPlayerStatistics.API.Validators
{
    public class PlayerPostFormModelValidator : AbstractValidator<PlayerPostFormModel>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IClubRepository _clubRepository;

        public PlayerPostFormModelValidator(IPositionRepository positionRepository,IClubRepository clubRepository)
        {
            _positionRepository = positionRepository;
            _clubRepository = clubRepository;

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.AST).NotEmpty();
            RuleFor(x => x.REB).NotEmpty();
            RuleFor(x => x.PTS).NotEmpty();
            RuleFor(x => x.PER).NotEmpty();
            RuleFor(x => x.PositionId).NotEmpty().Must(id =>
            {
                var position = _positionRepository.GetAllPositionsAsync().Result.ToList().FirstOrDefault(x => x.Id == id);
                if (position == null)
                    return false;
                return true;
            }
                ).WithMessage("Please select valid Position!");
            RuleFor(x => x.ClubId).NotEmpty().Must(id =>
            {
                var club = _clubRepository.GetAllClubsAsync().Result.ToList().FirstOrDefault(x => x.Id == id);
                if (club == null)
                    return false;
                return true;
            }).WithMessage("Please select valid Club!");
   
        }
    }
}
