using GameShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameShop.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Price);

            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);

            builder.Property(x => x.Type).IsRequired();

            builder.HasOne(x => x.GameType).WithMany(x => x.Games);
        }
    }
}
