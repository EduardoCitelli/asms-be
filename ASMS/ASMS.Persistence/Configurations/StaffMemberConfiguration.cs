using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class StaffMemberConfiguration : IEntityTypeConfiguration<StaffMember>
    {
        public void Configure(EntityTypeBuilder<StaffMember> builder)
        {
            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.StaffMembers)
                   .HasForeignKey(x => x.InstituteId);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.StaffMember)
                   .HasForeignKey<StaffMember>(x => x.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}