using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASMS.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.HasQueryFilter(x => !x.IsDelete);

            builder.HasData(
                new Role
                {
                    Id = RoleTypeEnum.SuperAdmin,
                    Name = RoleTypeEnum.SuperAdmin.ToString(),
                    Description = "Super usuario con acceso a todos los modulos del sistema",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = RoleTypeEnum.Manager,
                    Name = RoleTypeEnum.Manager.ToString(),
                    Description = "Manager de la institución",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = RoleTypeEnum.StaffMember,
                    Name = RoleTypeEnum.StaffMember.ToString(),
                    Description = "Miembro administrativo de la institución",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = RoleTypeEnum.Coach,
                    Name = RoleTypeEnum.Coach.ToString(),
                    Description = "Profesor de la institución",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = RoleTypeEnum.Member,
                    Name = RoleTypeEnum.Member.ToString(),
                    Description = "Miembro/Cliente de la institución",
                    LastEditedBy = "admin",
                });
        }
    }
}
