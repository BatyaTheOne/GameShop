using GameShop.Controllers.DTO;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(CreateUserDto userDto)
        {
            var user = new User
            {
                Loggin = userDto.Loggin,
                Password = userDto.Password,
                DateOfBirth = userDto.DateOfBirth.Date,
                LastName = userDto.LastName,
                FirstName = userDto.FirstName
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

    }
}
