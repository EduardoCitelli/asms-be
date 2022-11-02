using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.Property(x => x.Salary)
                   .HasPrecision(16, 2);

            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.Coaches)
                   .HasForeignKey(x => x.InstituteId);

            builder.HasOne(x => x.User)
                   .WithOne()
                   .HasForeignKey<Coach>(x => x.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}