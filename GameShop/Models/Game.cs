using GameShop.Models.Enums;
namespace GameShop.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; } = 0;
        public string Description { get; set; }
        public GameTypeEnum Type { get; set; }
        public int GameTypeId { get; set; }
        public GameType GameType { get; set; }
        public string GameTypeName { get { return Type.ToString(); } }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
