﻿using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class InstituteClassConfiguration : IEntityTypeConfiguration<InstituteClass>
    {
        public void Configure(EntityTypeBuilder<InstituteClass> builder)
        {
            builder.Property(x => x.Description)
                   .IsRequired();

            builder.Property(x => x.StartTime)
                   .IsRequired();

            builder.Property(x => x.FinishTime)
                   .IsRequired();

            builder.Property(x => x.IsRecurrence)
                   .IsRequired();

            builder.HasOne(x => x.Activity)
                   .WithMany(x => x.InstituteClasses)
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.PrincipalCoach)
                   .WithMany(x => x.PrincipalClasses)
                   .HasForeignKey(x => x.PrincipalCoachId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.AuxCoach)
                   .WithMany(x => x.AuxClasses)
                   .HasForeignKey(x => x.AuxCoachId);

            builder.HasOne(x => x.Room)
                   .WithMany(x => x.InstituteClasses)
                   .HasForeignKey(x => x.RoomId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Institute)
                   .WithMany(x => x.InstituteClasses)
                   .HasForeignKey(x => x.InstituteId);
        }
    }
}
