using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteMemberConfiguration : IEntityTypeConfiguration<InstituteMember>
    {
        public void Configure(EntityTypeBuilder<InstituteMember> builder)
        {
            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.InstituteMembers)
                   .HasForeignKey(x => x.InstituteId);

            builder.HasOne(x => x.User)
                   .WithOne(x => x.InstituteMember)
                   .HasForeignKey<InstituteMember>(x => x.UserId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}