using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAPlayerStatistics.API.DataModels.Repositories;
using NBAPlayerStatistics.API.DomainModels;

namespace NBAPlayerStatistics.API.Controllers
{
    
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public ClubsController(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }
        [HttpGet("[controller]")]
        public async Task<ActionResult<List<ClubModel>>> GetAll()
        {
            List<ClubModel> result = null;

            try
            {
              var clubs =   await _clubRepository.GetAllClubsAsync();
                if(clubs == null)
                {
                    return this.StatusCode(404, "Club list not found.");
                }
                result = _mapper.Map<List<ClubModel>>(clubs);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
