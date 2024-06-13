using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteMemberActivitiesConfiguration : IEntityTypeConfiguration<InstituteMemberActivities>
    {
        public void Configure(EntityTypeBuilder<InstituteMemberActivities> builder)
        {
            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.InstituteMember)
                   .WithMany(x => x.AllowedActivities)
                   .HasForeignKey(x => x.InstituteMemberId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
