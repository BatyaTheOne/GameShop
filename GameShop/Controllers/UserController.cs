using GameShop.Models;
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

        public static bool IsActive = false;

        public UserController(AppDbContext appDbContext)
        {
             _context = appDbContext;
        }

        [HttpGet("Authorization")]
        public async Task<ActionResult> Authorization(string loggin, string password)
        {
            if (_context.Users.Any(x => x.Logging == loggin && x.Password == password) == true)
            {
                IsActive= true;
            }

            return Ok();
        }

        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(string loggin, string password)
        {
            var user = new User
            {
                Logging = loggin,
                Password = password
            };
            await _context.Users.AddAsync(user);
            return Ok( await _context.SaveChangesAsync());
        }

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
