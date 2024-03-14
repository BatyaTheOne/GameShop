using GameShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public LibraryController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLibrary()
        {
            await _db.Libraries.AddAsync(new Models.Library());
            return Ok( await _db.SaveChangesAsync());
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLibrary()
        {
            return Ok(await _db.Libraries.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLibrary(int id)
        {
            await _db.Libraries.Where(x => x.Id == id).ExecuteDeleteAsync();
            return Ok(await _db.SaveChangesAsync());
        }
    }
}
