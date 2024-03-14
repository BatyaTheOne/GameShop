using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Services
{
    public class AccountReplenishmentService : IAccountReplenishmentService
    {
        private readonly AppDbContext _db;

        public AccountReplenishmentService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task AddMoneyToScore(double money, int userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new Exception("Человек c такой Id нету");
            }
            user.Score += money;

            await _db.Users.Where(x => x.Id == userId).ExecuteUpdateAsync(x =>
                            x.SetProperty(u => u.Score, u => user.Score));
        }
    }
}
