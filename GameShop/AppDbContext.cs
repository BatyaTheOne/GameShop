using Microsoft.EntityFrameworkCore;
using GameShop.Models;
using GameShop.Models.Enums;
using GameShop.Configurations;

namespace GameShop
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserGame> UserGames { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfiguration());

            modelBuilder.Entity<GameType>().HasData(
                new GameType { Id = 1, Name = "Action" },
                new GameType { Id = 2, Name = "Shooter" },
                new GameType { Id = 3, Name = "RPG" },
                new GameType { Id = 4, Name = "Strategy" },
                new GameType { Id = 5, Name = "Simulation" },
                new GameType { Id = 6, Name = "Adventure" },
                new GameType { Id = 7, Name = "Sports" }
                );
        }
    }
}
