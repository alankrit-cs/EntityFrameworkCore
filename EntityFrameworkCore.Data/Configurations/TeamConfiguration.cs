using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team { Id = 1, Name = "India", CreatedDate = DateTime.UtcNow },
                new Team { Id = 2, Name = "Portugal", CreatedDate = DateTime.UtcNow },
                new Team { Id = 3, Name = "Brazil", CreatedDate = DateTime.UtcNow }
            );
        }
    }
}
