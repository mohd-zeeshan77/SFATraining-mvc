using Microsoft.EntityFrameworkCore;

namespace WebTestMVC.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
       
       
        public DbSet<State> State { get; init; }
        public DbSet<City> City {  get; init; }

    }
}
