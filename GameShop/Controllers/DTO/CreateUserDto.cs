using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameShop.Controllers.DTO
{
    public record CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Loggin { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
