using GameShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace GameShop.Services
{
    public class BuyService : IBuyService
    {
        private readonly AppDbContext _db;
        private readonly IGameService _gameService;

        public BuyService(AppDbContext db, IGameService gameService)
        {
            _db = db;
            _gameService = gameService;
        }

        public async Task<Game> Buy(int UserID, int GameId)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Id == GameId);

            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == UserID);


            if (user.Score >= game.Price)
            {
                user.Score -= game.Price;
            }
            else
            {
                throw new Exception("У вас не хватает денег иди работай");
            }

            if (game == null || user == null)
                throw new Exception("Такой игры нет в наличии или у вас не хватает денег");

            if (await _db.UserGames.AnyAsync( x => x.UserId == UserID && x.GameId == GameId))
            {
                throw new Exception("Игра уже в наличии");
            }
            var userGame = new UserGame
            {
                UserId = UserID,
                GameId = GameId,
            };

            await _db.UserGames.AddAsync(userGame);

            await _db.SaveChangesAsync();

            return game;

        }
    }
}
