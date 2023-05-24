using Microsoft.EntityFrameworkCore;

namespace BeerbliotekWebApplication.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Beer> Beers { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
