using Books.DataAccess.DataContext;
using Books.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly DatabaseContext _databaseContext;
        public GenericRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntry = await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _databaseContext.AddRangeAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            var addedEntry = _databaseContext.Remove(entity);
            return await _databaseContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _databaseContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _databaseContext.Set<TEntity>().ToListAsync() : _databaseContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var addedEntry = _databaseContext.Update(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _databaseContext.UpdateRange(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }
    }
}
