using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.WithDocker.SqlServer
{
    public  class AccessioningDbContext :DbContext
    {
        public AccessioningDbContext(DbContextOptions<AccessioningDbContext> options) : base(options)
        {
        }

        public DbSet<InsuranceProvider> InsuranceProviders { get; set; }
    }
}