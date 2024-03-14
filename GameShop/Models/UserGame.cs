using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
    public class UserGame
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }

        public int? GameId { get; set; }

        public List<Game> Games { get; set;} = new List<Game>();
        public List<User> Users { get; set;} = new List<User>();

    }
}
