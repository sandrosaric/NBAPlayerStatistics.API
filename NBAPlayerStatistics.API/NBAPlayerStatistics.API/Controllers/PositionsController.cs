using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAPlayerStatistics.API.DataModels.Repositories;
using NBAPlayerStatistics.API.DomainModels;

namespace NBAPlayerStatistics.API.Controllers
{
 
    [ApiController]
    public class PositionsController : ControllerBase
    {

        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionsController(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        [HttpGet("[controller]")]
        public async Task<ActionResult<List<PositionModel>>> GetAll()
        {
            List<PositionModel> result = null;

            try
            {
                var clubs = await _positionRepository.GetAllPositionsAsync();
                if(clubs == null)
                {
                    return this.StatusCode(404, "Position list not found.");
                }
                result = _mapper.Map<List<PositionModel>>(clubs);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
