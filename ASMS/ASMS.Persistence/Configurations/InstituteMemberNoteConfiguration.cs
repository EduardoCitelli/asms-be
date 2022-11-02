using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteMemberNoteConfiguration : IEntityTypeConfiguration<InstituteMemberNote>
    {
        public void Configure(EntityTypeBuilder<InstituteMemberNote> builder)
        {
            builder.HasOne(x => x.InstituteMember)
                   .WithMany(x => x.Notes)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Coach)
                   .WithMany()
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}