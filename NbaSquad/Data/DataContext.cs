using Microsoft.EntityFrameworkCore;
using NbaSquad.Models;

namespace NbaSquad.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(h => h.Team)
                .WithMany(a => a.Players)
                .HasForeignKey(p => p.TeamId);
        }
    }
}