using GameShop.DTO;
using GameShop.Models;

namespace GameShop.Services
{
    public interface IGameService
    {
        public Task<Game> Get(int id);

        public Task Add(GameDto game);

        public Task<List<Game>> GatAll();
        public Task Delete(int Id);
        public Task Update(GameUpdateDto gameDto);
    }
}
