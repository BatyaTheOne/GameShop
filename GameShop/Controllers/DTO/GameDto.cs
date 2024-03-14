
using GameShop.Models.Enums;

namespace GameShop.DTO
{
    public class GameDto
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public GameTypeEnum Type { get; set; }
    }
}
