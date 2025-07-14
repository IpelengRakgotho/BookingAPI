using Microsoft.EntityFrameworkCore;
using ResourceBookingSystemAPI.Entities;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Resource> Resource { get; set; }
        public DbSet<Booking> Booking { get; set; }
       

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
