using Microsoft.EntityFrameworkCore;
using ResourceBookingSystemAPI.Entities;
using ResourceBookingSystemAPI.Interfaces;

namespace ResourceBookingSystemAPI.DBData
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) ,IApplicationDbContext
    {
     
        public DbSet<Resource> Resource { get; set; }
        public DbSet<Booking> Booking { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many: Resource has many Bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Resource)
                .WithMany(r => r.Booking)
                .HasForeignKey(b => b.ResourceId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade on delete
        }
    }
}
