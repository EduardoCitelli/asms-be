using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
    {
        public void Configure(EntityTypeBuilder<MembershipType> builder)
        {
            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.MembershipTypes)
                   .HasForeignKey(x => x.InstituteId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}