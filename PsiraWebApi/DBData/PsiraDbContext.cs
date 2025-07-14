using Microsoft.EntityFrameworkCore;
using PsiraWebApi.Entities;
using PsiraWebApi.Interfaces;

namespace PsiraWebApi.DBData
{
    public class PsiraDbContext(DbContextOptions<PsiraDbContext> options) : DbContext(options) ,IPsiraDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<Documents> Documents { get; set; }

        #region set method with Tentity
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion set method with Tentity

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
