using GameShop.Models;

namespace GameShop.Services
{
    public interface IBuyService
    {
        Task<Game> Buy(int UserId, int GameId);
    }
}