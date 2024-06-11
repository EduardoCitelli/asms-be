using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteMemberMembershipConfiguration : IEntityTypeConfiguration<InstituteMemberMembership>
    {
        public void Configure(EntityTypeBuilder<InstituteMemberMembership> builder)
        {
            builder.HasOne(x => x.InstituteMember)
                   .WithMany(x => x.Memberships)
                   .HasForeignKey(x => x.InstituteMemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Membership)
                   .WithMany()
                   .HasForeignKey(x => x.MembershipId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasAlternateKey(x => new { x.InstituteMemberId, x.MembershipId, x.StartDate });
        }
    }
}