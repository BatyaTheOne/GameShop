using GameShop.Controllers.DTO;
using GameShop.Models;
using GameShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameShop.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserService _userService;

        public static bool IsActive = false;

        public UserController(AppDbContext appDbContext, UserService userService)
        {
             _context = appDbContext;
             _userService = userService;
        }

        [HttpGet("Authorization")]
        public async Task<ActionResult> Authorization(string loggin, string password)
        {
            if (_context.Users.Any(x => x.Loggin == loggin && x.Password == password) == true)
            {
                IsActive= true;
            }

            return Ok();
        }

        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(CreateUserDto userDto)
        {
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Пополнение счета
        /// </summary>
        /// <param name="money"> деньги</param>
        /// <param name="userId">ID пользовалтеля</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("AccountReplenishment")]
        public async Task<ActionResult> AccountReplenishment(double money, int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new Exception("Человек c такой Id нету");
            }

            user.Score += money;

            await _context.Users.Where(x => x.Id == userId).ExecuteUpdateAsync(x => 
                            x.SetProperty(u => u.Score, u => user.Score));

            return Ok();
        }
    }


}
