﻿using AutoMapper;
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
        private readonly IImageRepository _imageRepository;

        public PlayersController(IPlayerRepository playerRepository,IMapper mapper,IImageRepository imageRepository)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
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
        public async Task<ActionResult<PlayerModel>> Put(Guid playerId, PlayerPutFormModel playerFormModel)
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



        [HttpDelete("[controller]/{playerId:guid}")]
        public async Task<ActionResult<PlayerModel>> Delete(Guid playerId)
        {
            PlayerModel result = null;

            try
            {
                var player = await _playerRepository.DeletePlayerAsync(playerId);
                if(player == null)
                {
                    return NotFound("Player not found.");
                }
                result = _mapper.Map<PlayerModel>(player);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[controller]/add")]
        public async Task<ActionResult<PlayerModel>> Post(PlayerPostFormModel playerPostFormModel)
        {
            PlayerModel result = null;

            try
            {
                Player player = _mapper.Map<Player>(playerPostFormModel);
                Player createdPlayer = await _playerRepository.CreatePlayerAsync(player);
                if (createdPlayer == null) return BadRequest();
                result = _mapper.Map<PlayerModel>(createdPlayer);
                return CreatedAtAction(nameof(GetAll),new {playerId = result.Id},result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[controller]/{playerId:guid}/upload-image")]
        public async Task<ActionResult> UploadImage([FromRoute] Guid playerId,IFormFile profileImage)
        {
            List<string> allowedExtensions = new List<string>()
            {
                ".png",
                ".gif",
                ".jpg",
                ".jpeg"
            };
            if(profileImage != null && profileImage.Length > 0)
            {
                if (allowedExtensions.Contains(Path.GetExtension(profileImage.FileName))){
                    if (await _playerRepository.ExistsAsync(playerId))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                        var fileImagePath = await _imageRepository.UploadImageAsync(profileImage, fileName);
                        bool success = await _playerRepository.UpdateProfileImgAsync(playerId, fileImagePath);
                        if (success)
                        {
                            return Ok(fileImagePath);
                        }
                        else
                        {
                            return this.StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image :(");
                        }
                    }
                }
            }
           
            return this.StatusCode(StatusCodes.Status404NotFound, "Image not found.");
        }
    }
}
