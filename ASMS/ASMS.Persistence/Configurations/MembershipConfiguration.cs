using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Property(x => x.Price)
                   .HasPrecision(16, 2);

            builder.HasOne(x => x.MembershipType)
                   .WithMany(x => x.Memberships)
                   .HasForeignKey(x => x.MembershipTypeId);

            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.Memberships)
                   .HasForeignKey(x => x.InstituteId);
        }
    }
}
