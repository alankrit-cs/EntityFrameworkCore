using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasData(
                new League { Id = 1, Name = "Indian Premier League", CreatedDate = DateTime.UtcNow },
                new League { Id = 2, Name = "Big Bash League", CreatedDate = DateTime.UtcNow },
                new League { Id = 3, Name = "World Cup", CreatedDate = DateTime.UtcNow }
            );
        }
    }
}
