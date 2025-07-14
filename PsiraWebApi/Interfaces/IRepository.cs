using System.Linq.Expressions;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddAsync(List<TEntity> entities);
        Task<TEntity?> GetAsync(long id);
        Task<TEntity?> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity?, bool>> predicate, params Expression<Func<TEntity?, object>>[] includes);
        Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity?>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        TEntity Update(TEntity entity);
        List<TEntity> Update(List<TEntity> entities);
        Task<TEntity> DeleteAsync(long id);
        Task<TEntity> DeleteAsync(int id);
        Task<List<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        //List<TEntity> FromSqlRaw(string sql);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
