using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDelete", "LastEditedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4902), "Super usuario con acceso a todos los modulos del sistema", false, "admin", "SuperAdmin", new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4902) },
                    { 2, new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4972), "Manager de la institución", false, "admin", "Manager", new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4972) },
                    { 3, new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4975), "Miembro administrativo de la institución", false, "admin", "StaffMember", new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4975) },
                    { 4, new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4977), "Profesor de la institución", false, "admin", "Coach", new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4978) },
                    { 5, new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4979), "Miembro/Cliente de la institución", false, "admin", "Member", new DateTime(2022, 9, 22, 15, 58, 15, 776, DateTimeKind.Utc).AddTicks(4980) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
