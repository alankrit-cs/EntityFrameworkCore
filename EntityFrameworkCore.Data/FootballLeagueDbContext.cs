using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public string DbPath { get; private set; }

        public FootballLeagueDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Combine(path, "FootballLeague_EfCore.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source= {DbPath}")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
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
