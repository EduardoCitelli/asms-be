using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteMemberInstituteClassBlockConfiguration : IEntityTypeConfiguration<InstituteMemberInstituteClassBlock>
    {
        public void Configure(EntityTypeBuilder<InstituteMemberInstituteClassBlock> builder)
        {
            builder.HasOne(x => x.InstituteMember)
                   .WithMany(x => x.Classes)
                   .HasForeignKey(x => x.InstituteMemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ClassTaked)
                   .WithMany(x => x.InstituteMembers)
                   .HasForeignKey(x => x.InstituteClassBlockId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasAlternateKey(x => new { x.InstituteMemberId, x.InstituteClassBlockId });
        }
    }
}