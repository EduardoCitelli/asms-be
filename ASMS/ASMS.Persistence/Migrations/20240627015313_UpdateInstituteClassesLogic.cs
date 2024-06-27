using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class UpdateInstituteClassesLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstituteMemberInstituteClasses");

            migrationBuilder.DropColumn(
                name: "ClassStatus",
                table: "InstituteClasses");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "InstituteClasses",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FinishTime",
                table: "InstituteClasses",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InstituteClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromRange",
                table: "InstituteClasses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurrence",
                table: "InstituteClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToRange",
                table: "InstituteClasses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstituteClassBlocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteClassId = table.Column<long>(type: "bigint", nullable: false),
                    PrincipalCoachId = table.Column<long>(type: "bigint", nullable: false),
                    AuxCoachId = table.Column<long>(type: "bigint", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteClassBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteClassBlocks_Coaches_AuxCoachId",
                        column: x => x.AuxCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteClassBlocks_Coaches_PrincipalCoachId",
                        column: x => x.PrincipalCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteClassBlocks_InstituteClasses_InstituteClassId",
                        column: x => x.InstituteClassId,
                        principalTable: "InstituteClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteClassBlocks_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteClassBlocks_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstituteClassDayOfWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InstituteClassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteClassDayOfWeek", x => x.Id);
                    table.UniqueConstraint("AK_InstituteClassDayOfWeek_InstituteClassId_Id", x => new { x.InstituteClassId, x.Id });
                    table.ForeignKey(
                        name: "FK_InstituteClassDayOfWeek_InstituteClasses_InstituteClassId",
                        column: x => x.InstituteClassId,
                        principalTable: "InstituteClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstituteMemberInstituteClassBlocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteMemberId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteClassBlockId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMemberInstituteClassBlocks", x => x.Id);
                    table.UniqueConstraint("AK_InstituteMemberInstituteClassBlocks_InstituteMemberId_InstituteClassBlockId", x => new { x.InstituteMemberId, x.InstituteClassBlockId });
                    table.ForeignKey(
                        name: "FK_InstituteMemberInstituteClassBlocks_InstituteClassBlocks_InstituteClassBlockId",
                        column: x => x.InstituteClassBlockId,
                        principalTable: "InstituteClassBlocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteMemberInstituteClassBlocks_InstitutesMembers_InstituteMemberId",
                        column: x => x.InstituteMemberId,
                        principalTable: "InstitutesMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8605), new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8721), new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8722) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8724), new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8724) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8727), new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8727) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8729), new DateTime(2024, 6, 27, 1, 53, 13, 309, DateTimeKind.Utc).AddTicks(8729) });

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClassBlocks_AuxCoachId",
                table: "InstituteClassBlocks",
                column: "AuxCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClassBlocks_InstituteClassId",
                table: "InstituteClassBlocks",
                column: "InstituteClassId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClassBlocks_InstituteId",
                table: "InstituteClassBlocks",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClassBlocks_PrincipalCoachId",
                table: "InstituteClassBlocks",
                column: "PrincipalCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteClassBlocks_RoomId",
                table: "InstituteClassBlocks",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberInstituteClassBlocks_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks",
                column: "InstituteClassBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstituteClassDayOfWeek");

            migrationBuilder.DropTable(
                name: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.DropTable(
                name: "InstituteClassBlocks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InstituteClasses");

            migrationBuilder.DropColumn(
                name: "FromRange",
                table: "InstituteClasses");

            migrationBuilder.DropColumn(
                name: "IsRecurrence",
                table: "InstituteClasses");

            migrationBuilder.DropColumn(
                name: "ToRange",
                table: "InstituteClasses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "InstituteClasses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishTime",
                table: "InstituteClasses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "ClassStatus",
                table: "InstituteClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InstituteMemberInstituteClasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteClassId = table.Column<long>(type: "bigint", nullable: false),
                    InstituteMemberId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMemberInstituteClasses", x => x.Id);
                    table.UniqueConstraint("AK_InstituteMemberInstituteClasses_InstituteMemberId_InstituteClassId", x => new { x.InstituteMemberId, x.InstituteClassId });
                    table.ForeignKey(
                        name: "FK_InstituteMemberInstituteClasses_InstituteClasses_InstituteClassId",
                        column: x => x.InstituteClassId,
                        principalTable: "InstituteClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteMemberInstituteClasses_InstitutesMembers_InstituteMemberId",
                        column: x => x.InstituteMemberId,
                        principalTable: "InstitutesMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(4894), new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5004), new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5007), new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5010), new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5012), new DateTime(2024, 6, 13, 1, 31, 5, 388, DateTimeKind.Utc).AddTicks(5012) });

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberInstituteClasses_InstituteClassId",
                table: "InstituteMemberInstituteClasses",
                column: "InstituteClassId");
        }
    }
}
