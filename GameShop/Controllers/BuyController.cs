using GameShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    [ApiController]
    [Route("api/buy")]
    public class BuyController : ControllerBase
    {
        private readonly IBuyService _buyService;

        public BuyController(IBuyService buyService)
        {
            _buyService = buyService;
        }

        [HttpGet]
        public async Task<IActionResult> BuyGame(int UserID, int GameID)
        {
            return Ok(await _buyService.Buy(UserID, GameID));
        }
    }
}
