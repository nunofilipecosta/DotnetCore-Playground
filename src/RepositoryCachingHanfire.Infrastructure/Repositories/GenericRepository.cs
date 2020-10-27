using Hangfire;
using Microsoft.EntityFrameworkCore;
using RepositoryCachingHanfire.Core.Enums;
using RepositoryCachingHanfire.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCachingHanfire.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly static CacheTech cacheTech = CacheTech.Memory;
        private readonly string cacheKey = $"{typeof(T)}";
        private readonly ApplicationDbContext _dbContext;
        private readonly Func<CacheTech, ICacheService> _cacheServiceFunc;


        public GenericRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheServiceFunc)
        {
            _dbContext = dbContext;
            _cacheServiceFunc = cacheServiceFunc;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            BackgroundJob.Enqueue(() => RefreshCache());
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            BackgroundJob.Enqueue(() => RefreshCache());
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (!_cacheServiceFunc(cacheTech).TryGet(cacheKey, out IReadOnlyList<T> cachedList))
            {
                cachedList = await _dbContext.Set<T>().ToListAsync();
                _cacheServiceFunc(cacheTech).Set(cacheKey, cachedList);
            }
            return cachedList;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            BackgroundJob.Enqueue(() => RefreshCache());
        }

        public async Task RefreshCache()
        {
            _cacheServiceFunc(cacheTech).Remove(cacheKey);
            var cachedList = await _dbContext.Set<T>().ToListAsync();
            _cacheServiceFunc(cacheTech).Set(cacheKey, cachedList);
        }
    }
}
