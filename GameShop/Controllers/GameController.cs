using GameShop.DTO;
using GameShop.Models;
using GameShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
    [ApiController]
    [Route("api-games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService) 
        { 
            _gameService = gameService;
        }

        [HttpGet("game")]
        public async Task<ActionResult> GetGame(int Id)
        {
            var game = await _gameService.Get(Id);

            if (game == null)
            {
                return BadRequest();
            }

            return Ok(game);
        }

        [HttpGet]
        public async Task<ActionResult> GetGames()
        {
            var games = await _gameService.GatAll();
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult> PostGame(GameDto game) 
        {
            await _gameService.Add(game);
            return Ok();
            ///asd
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGame(int Id)
        {
            await _gameService.Delete(Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(GameUpdateDto gameDto)
        {
            await _gameService.Update(gameDto);
            return NoContent();
        }

    }
}
