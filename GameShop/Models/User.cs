using System.Diagnostics.Eventing.Reader;

namespace GameShop.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Logging { get ; set; }

        public string Password { get; set; }

        public double Score { get; set; }
    }
}
