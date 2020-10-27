using Microsoft.EntityFrameworkCore;

namespace RepositoryCachingHanfire.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
