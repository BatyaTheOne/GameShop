using GameShop.Models.Enums;

namespace GameShop.DTO
{
    public class GameUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public GameTypeEnum Type { get; set; }
    }
}
