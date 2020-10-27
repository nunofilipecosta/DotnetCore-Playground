using Microsoft.EntityFrameworkCore;
using RepositoryCachingHanfire.Core.Enums;
using RepositoryCachingHanfire.Core.Interfaces;
using System;

namespace RepositoryCachingHanfire.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private DbSet<Customer> _customers;
        public CustomerRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheServiceFunc) : base(dbContext, cacheServiceFunc)
        {
            _customers = dbContext.Set<Customer>();
        }
    }
}
