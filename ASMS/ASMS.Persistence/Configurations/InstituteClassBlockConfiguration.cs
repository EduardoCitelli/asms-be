using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMS.Persistence.Configurations
{
    public class InstituteClassBlockConfiguration : IEntityTypeConfiguration<InstituteClassBlock>
    {
        public void Configure(EntityTypeBuilder<InstituteClassBlock> builder)
        {
            builder.Property(x => x.ClassStatus)
                   .IsRequired();

            builder.Property(x => x.StartTime)
                   .IsRequired();

            builder.Property(x => x.FinishTime)
                   .IsRequired();

            builder.HasOne(x => x.PrincipalCoach)
                   .WithMany(x => x.PrincipalBlocks)
                   .HasForeignKey(x => x.PrincipalCoachId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.AuxCoach)
                   .WithMany(x => x.AuxBlocks)
                   .HasForeignKey(x => x.AuxCoachId);

            builder.HasOne(x => x.Room)
                   .WithMany(x => x.Blocks)
                   .HasForeignKey(x => x.RoomId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.InstituteClassBlocks)
                   .HasForeignKey(x => x.InstituteId);

            builder.HasOne(x => x.Header)
                   .WithMany(x => x.Blocks)
                   .HasForeignKey(x => x.InstituteClassId)
                   .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}