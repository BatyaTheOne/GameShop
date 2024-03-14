using System.Net;

namespace GameShop.Models
{
    public class GameType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
