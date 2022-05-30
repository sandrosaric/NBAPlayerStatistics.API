using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAPlayerStatistics.API.DataModels.Repositories;
using NBAPlayerStatistics.API.DomainModels;

namespace NBAPlayerStatistics.API.Controllers
{

    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerRepository playerRepository,IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        [HttpGet("[controller]")]
        public async Task<ActionResult<List<PlayerModel>>> Index()
        {
            List<PlayerModel> result = null;
            try
            {
                var players = await _playerRepository.GetAllAsync();
                result = _mapper.Map<List<PlayerModel>>(players);
                return Ok(result);  

            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
