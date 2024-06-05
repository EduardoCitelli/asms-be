using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstitutePlanConfiguration : IEntityTypeConfiguration<InstitutePlan>
    {
        public void Configure(EntityTypeBuilder<InstitutePlan> builder)
        {
            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.InstitutePlans)
                   .HasForeignKey(x => x.InstituteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Plan)
                   .WithMany()
                   .HasForeignKey(x => x.PlanId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
