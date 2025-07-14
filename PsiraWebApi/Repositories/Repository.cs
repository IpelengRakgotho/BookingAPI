using Microsoft.EntityFrameworkCore;
using PsiraWebApi.Interfaces;
using System.Linq.Expressions;

namespace PsiraWebApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly IPsiraDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(IPsiraDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity?> GetAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }

        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            SaveChanges();
            return entity;
        }

        public List<TEntity> Update(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            SaveChanges();
            return entities;
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
            return entity;
        }

        public async Task<List<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var entities = await GetAllAsync(predicate, includes);
            if (entities.Any())
            {
                _dbSet.RemoveRange(entities);
                await SaveChangesAsync();
            }
            return entities;
        }

        public List<TEntity> FromSqlRaw(string sql)
        {
            return _dbSet.FromSqlRaw(sql).ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
            return entity;
        }
    }
}
