using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.Activities)
                   .HasForeignKey(x => x.InstituteId);
        }
    }
}