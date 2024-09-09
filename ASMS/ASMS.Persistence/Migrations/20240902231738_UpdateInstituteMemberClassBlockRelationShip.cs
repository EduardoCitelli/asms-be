using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class UpdateInstituteMemberClassBlockRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstituteClassBlocks_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstitutesMembers_InstituteMemberId",
                table: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_InstituteMemberInstituteClassBlocks_InstituteMemberId_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8847), new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8848) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8944), new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8992), new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8995), new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8998), new DateTime(2024, 9, 2, 23, 17, 38, 184, DateTimeKind.Utc).AddTicks(8999) });

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberInstituteClassBlocks_InstituteMemberId",
                table: "InstituteMemberInstituteClassBlocks",
                column: "InstituteMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstituteClassBlocks_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks",
                column: "InstituteClassBlockId",
                principalTable: "InstituteClassBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstitutesMembers_InstituteMemberId",
                table: "InstituteMemberInstituteClassBlocks",
                column: "InstituteMemberId",
                principalTable: "InstitutesMembers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstituteClassBlocks_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstitutesMembers_InstituteMemberId",
                table: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.DropIndex(
                name: "IX_InstituteMemberInstituteClassBlocks_InstituteMemberId",
                table: "InstituteMemberInstituteClassBlocks");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InstituteMemberInstituteClassBlocks_InstituteMemberId_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks",
                columns: new[] { "InstituteMemberId", "InstituteClassBlockId" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8589), new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8591) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8695), new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8695) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8698), new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8698) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8700), new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8701) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8761), new DateTime(2024, 7, 10, 23, 30, 3, 324, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstituteClassBlocks_InstituteClassBlockId",
                table: "InstituteMemberInstituteClassBlocks",
                column: "InstituteClassBlockId",
                principalTable: "InstituteClassBlocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMemberInstituteClassBlocks_InstitutesMembers_InstituteMemberId",
                table: "InstituteMemberInstituteClassBlocks",
                column: "InstituteMemberId",
                principalTable: "InstitutesMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
