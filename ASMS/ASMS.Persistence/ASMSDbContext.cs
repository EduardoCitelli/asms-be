using ASMS.Domain.Abstractions;
using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace ASMS.Persistence
{
    public partial class ASMSDbContext : DbContext
    {
        public ASMSDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<User> Users => Set<User>();
        public virtual DbSet<Role> Roles => Set<Role>();
        public virtual DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddAuditInfo()
        {
            var notDeletedEntries = ChangeTracker.Entries()
                                                 .Where(GetNotDeletedEntries());

            foreach (var entry in notDeletedEntries)
            {
                if (entry.State == EntityState.Added)
                    ((IAuditEntity)entry.Entity).CreatedAt = DateTime.UtcNow;

                ((IAuditEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }

            var deletedEntries = ChangeTracker.Entries()
                                              .Where(GetDeletedEntries());

            foreach (var entry in deletedEntries)
            {
                entry.State = EntityState.Modified;

                ((IAuditEntity)entry.Entity).IsDelete = true;
                ((IAuditEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        private Func<EntityEntry, bool> GetNotDeletedEntries() => x => x.Entity is IAuditEntity &&
                                                                       x.State != EntityState.Deleted &&
                                                                       x.State != EntityState.Unchanged;

        private Func<EntityEntry, bool> GetDeletedEntries() => x => x.Entity is IAuditEntity &&
                                                                    x.State == EntityState.Deleted;
    }
}