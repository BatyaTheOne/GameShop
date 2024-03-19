using GameShop.DTO;

namespace GameShop.Services
{
    public interface IUserService
    {
        Task Create(CreateUserDto userDto);
    }
}