using Microsoft.EntityFrameworkCore;
using PsiraWebApi.Entities;

namespace PsiraWebApi.Interfaces
{
    public interface IPsiraDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<Documents> Documents { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
