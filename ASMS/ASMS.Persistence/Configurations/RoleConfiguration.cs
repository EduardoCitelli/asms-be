using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.Property(x => x.Name)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.HasQueryFilter(x => !x.IsDelete);
        }
    }
}
