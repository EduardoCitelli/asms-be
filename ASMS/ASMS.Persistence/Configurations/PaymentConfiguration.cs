using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.Amount)
                   .HasPrecision(16, 3);

            builder.Property(x => x.PaymentType)
                   .IsRequired();

            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.Payments)
                   .HasForeignKey(x => x.InstituteId);

            builder.HasOne(x => x.MembershipPayment)
                   .WithMany(x => x.Payments)
                   .HasForeignKey(x => x.InstituteMemberMembershipId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}