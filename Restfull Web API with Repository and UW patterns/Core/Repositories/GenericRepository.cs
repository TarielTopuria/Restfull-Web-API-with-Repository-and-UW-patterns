﻿using Microsoft.EntityFrameworkCore;
using Restfull_Web_API_with_Repository_and_UW_patterns.Core.IRepositories;
using Restfull_Web_API_with_Repository_and_UW_patterns.Data;

namespace Restfull_Web_API_with_Repository_and_UW_patterns.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
