using GameShop.Controllers.DTO;

namespace GameShop.Services
{
    public interface IUserService
    {
        Task Create(CreateUserDto userDto);
    }
}