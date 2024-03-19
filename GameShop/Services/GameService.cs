using GameShop.DTO;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _db;
        public GameService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<Game> Get(int id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);
            return game;
        }

        public async Task<List<Game>> GatAll()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task Add(GameDto gamedto)
        {
            var game = new Game()
            {
                Name = gamedto.Name,
                Price = gamedto.Price,
                Description = gamedto.Description,
                Type = gamedto.Type,
                GameTypeId = ((int)gamedto.Type),
                MinimumLimitAge = gamedto.AgeLimit,
                LibraryId = 1
            };
                
            await _db.Games.AddAsync(game);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            await _db.Games.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task Update(GameUpdateDto gameDto)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Id == gameDto.Id);

            if (game == null)
            {
                throw new Exception("Такого ID Нет");
            }

            game.Name = gameDto.Name;
            game.Price = gameDto.Price;
            game.Description = gameDto.Description;
            game.Type = gameDto.Type;
        }
    }
}
