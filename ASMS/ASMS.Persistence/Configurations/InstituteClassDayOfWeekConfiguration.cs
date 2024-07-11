using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    internal class InstituteClassDayOfWeekConfiguration : IEntityTypeConfiguration<InstituteClassDayOfWeek>
    {
        public void Configure(EntityTypeBuilder<InstituteClassDayOfWeek> builder)
        {
            builder.HasOne(x => x.InstituteClass)
                   .WithMany(x => x.DaysOfWeek)
                   .HasForeignKey(x => x.InstituteClassId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasAlternateKey(x => new { x.InstituteClassId, x.DayOfWeek });
        }
    }
}
