namespace GameShop.Services
{
    public interface IAccountReplenishmentService
    {
        Task AddMoneyToScore(double money, int userId);
    }
}