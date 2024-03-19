using GameShop.DTO;
using GameShop.Models;
using GameShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
//    {
//  "firstName": "Бектур",
//  "lastName": "Токтобеков",
//  "loggin": "Bektur",
//  "password": "00000000",
//  "dateOfBirth": "2024-03-14T13:32:22.708Z"
//}
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
            if (UserController.IsActive == true)
            {
                var game = await _gameService.Get(Id);

                if (game == null)
                {
                    return BadRequest();
                }

                return Ok(game);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("Games")]
        public async Task<ActionResult> GetGames()
        {
            if (UserController.IsActive == true)
            {
                var games = await _gameService.GatAll();
                return Ok(games);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostGame(GameDto game)
        {
            if (UserController.IsActive == true)
            {
                await _gameService.Add(game);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGame(int Id)
        {
            if (UserController.IsActive == true)
            {
                await _gameService.Delete(Id);
                return NoContent();
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(GameUpdateDto gameDto)
        {
            if (UserController.IsActive == true)
            {
                await _gameService.Update(gameDto);
                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
