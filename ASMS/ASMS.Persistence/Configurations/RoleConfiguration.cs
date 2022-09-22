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
                    Id = Domain.RoleTypeEnum.SuperAdmin,
                    Name = Domain.RoleTypeEnum.SuperAdmin.ToString(),
                    Description = "Super usuario con acceso a todos los modulos del sistema",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = Domain.RoleTypeEnum.Manager,
                    Name = Domain.RoleTypeEnum.Manager.ToString(),
                    Description = "Manager de la institución",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = Domain.RoleTypeEnum.StaffMember,
                    Name = Domain.RoleTypeEnum.StaffMember.ToString(),
                    Description = "Miembro administrativo de la institución",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = Domain.RoleTypeEnum.Coach,
                    Name = Domain.RoleTypeEnum.Coach.ToString(),
                    Description = "Profesor de la institución",
                    LastEditedBy = "admin",
                },
                new Role
                {
                    Id = Domain.RoleTypeEnum.Member,
                    Name = Domain.RoleTypeEnum.Member.ToString(),
                    Description = "Miembro/Cliente de la institución",
                    LastEditedBy = "admin",
                });
        }
    }
}
