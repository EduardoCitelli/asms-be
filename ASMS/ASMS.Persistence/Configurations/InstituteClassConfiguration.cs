using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteClassConfiguration : IEntityTypeConfiguration<InstituteClass>
    {
        public void Configure(EntityTypeBuilder<InstituteClass> builder)
        {
            builder.Property(x => x.ClassStatus)
                   .IsRequired();

            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.PrincipalCoach)
                   .WithMany(x => x.PrincipalClasses)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.AuxCoach)
                   .WithMany(x => x.AuxClasses);

            builder.HasOne(x => x.Room)
                   .WithMany()
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.InstituteClasses)
                   .HasForeignKey(x => x.InstituteId);
        }
    }
}
