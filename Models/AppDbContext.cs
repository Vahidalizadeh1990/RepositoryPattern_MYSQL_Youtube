using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern_MySQL_Youtube.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Data can execute in this method.
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Music> Music { get; set; }
    }
}