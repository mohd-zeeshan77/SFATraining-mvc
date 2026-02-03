using Microsoft.EntityFrameworkCore;

namespace WebTestMVC.Data
{
    public sealed class AppDbContext : DbContext
    {

        public DbSet<State> state { get; init; }
        public DbSet<City> city {  get; init; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-P0SEVP8\\SQLEXPRESS;Database=MyApp;TrustServerCertificate=true;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
