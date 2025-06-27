using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source= FootballLeague_EfCore.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "India",
                    CreatedDate = DateTime.UtcNow
                },
                new Team
                {
                    TeamId = 2,
                    Name = "Protugal",
                    CreatedDate = DateTime.UtcNow
                },
                new Team
                {
                    TeamId = 3,
                    Name = "Brazil",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
