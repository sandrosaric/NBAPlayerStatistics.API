using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAPlayerStatistics.API.DataModels;
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
        public async Task<ActionResult<List<PlayerModel>>> GetAll()
        {
            List<PlayerModel> result = null;
            try
            {
                var players = await _playerRepository.GetAllPlayersAsync();
                result = _mapper.Map<List<PlayerModel>>(players);
                return Ok(result);  

            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        
        [HttpGet("[controller]/{playerId:guid}")]
        public async Task<ActionResult<PlayerModel>> GetById([FromRoute] Guid playerId)
        {
            PlayerModel result = null;
            try
            {
                var player = await _playerRepository.GetPlayerByIdAsync(playerId);
                if(player == null)
                {
                    return this.StatusCode(404, "Player not found.");
                }
                result = _mapper.Map<PlayerModel>(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }



        [HttpPut("[controller]/{playerId:guid}")]
        public async Task<ActionResult<PlayerModel>> Put(Guid playerId, PlayerFormModel playerFormModel)
        {
            PlayerModel result = null;
            try
            {
                if(await _playerRepository.ExistsAsync(playerId))
                {
                    var player = _mapper.Map<Player>(playerFormModel);
                    Player updatedPlayer = await _playerRepository.UpdatePlayerAsync(playerId, player);
                    result = _mapper.Map<PlayerModel>(updatedPlayer);
                    return Ok(result);
                    
                }
                return this.StatusCode(404, "Player not found.");
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
