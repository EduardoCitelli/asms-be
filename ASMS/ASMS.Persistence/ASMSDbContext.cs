using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Abstractions;
using ASMS.Persistence.Conventions;
using ASMS.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Reflection;

namespace ASMS.Persistence
{
    public partial class ASMSDbContext : DbContext
    {
        private const string DateBdTypeName = "date";
        private const string DefaultEditedByUser = "admin";

        private readonly long _instituteId;
        private readonly IUserInfoService _userInfoService;

        public ASMSDbContext(DbContextOptions options,
                             IInstituteIdService instituteService,
                             IUserInfoService userInfoService)
            : base(options)
        {
            _instituteId = instituteService.InstituteId;
            _userInfoService = userInfoService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyApplicationQueryFilter(_instituteId);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var type = entity.ClrType;

                if (typeof(IIsInstituteEntity).IsAssignableFrom(type))
                {
                    var method = typeof(ASMSDbContext).GetMethod(nameof(GetInsituteIdFilter), BindingFlags.NonPublic | BindingFlags.Static)?
                                                      .MakeGenericMethod(type);

                    var filtro = method?.Invoke(null, new object[] { this })!;
                    entity.SetQueryFilter((LambdaExpression)filtro);
                }
            }

        }

        private static LambdaExpression GetInsituteIdFilter<TEntity>(ASMSDbContext context) where TEntity : class, IIsInstituteEntity
        {
            Expression<Func<TEntity, bool>> filter = x => x.InstituteId == context._instituteId && !x.IsDelete;
            return filter;
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateOnly>()
                                .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
                                .HaveColumnType(DateBdTypeName);
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
                ((IAuditEntity)entry.Entity).LastEditedBy = _userInfoService.Value?.UserName ?? DefaultEditedByUser;
            }

            var deletedEntries = ChangeTracker.Entries()
                                              .Where(GetDeletedEntries());

            foreach (var entry in deletedEntries)
            {
                entry.State = EntityState.Modified;

                ((IAuditEntity)entry.Entity).IsDelete = true;
                ((IAuditEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
                ((IAuditEntity)entry.Entity).LastEditedBy = _userInfoService.Value?.UserName ?? DefaultEditedByUser;
            }
        }

        private Func<EntityEntry, bool> GetNotDeletedEntries() => x => x.Entity is IAuditEntity &&
                                                                       x.State != EntityState.Deleted &&
                                                                       x.State != EntityState.Unchanged;

        private Func<EntityEntry, bool> GetDeletedEntries() => x => x.Entity is IAuditEntity &&
                                                                    x.State == EntityState.Deleted;
    }
}