using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName)
                   .IsRequired();

            builder.Property(x => x.FirstName)
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .IsRequired();

            builder.HasQueryFilter(x => !x.IsDelete);
        }
    }
}
