using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class NoteFileConfiguration : IEntityTypeConfiguration<NoteFile>
    {
        public void Configure(EntityTypeBuilder<NoteFile> builder)
        {
            builder.HasOne(x => x.InstituteMemberNote)
                   .WithMany(x => x.NoteFiles);
        }
    }
}