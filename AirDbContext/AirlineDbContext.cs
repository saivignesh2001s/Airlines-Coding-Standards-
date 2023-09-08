using Airlines.Model;
using Microsoft.EntityFrameworkCore;

namespace Airlines.AirDbContext
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options) : base(options) { 
        
        }
        public DbSet<Airline> Airlines { get; set; }
    }
}
