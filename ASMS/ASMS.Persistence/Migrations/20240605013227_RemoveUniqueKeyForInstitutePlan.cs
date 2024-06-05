using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class RemoveUniqueKeyForInstitutePlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMemberNotes_Users_UserId",
                table: "InstituteMemberNotes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_InstitutePlans_InstituteId_PlanId",
                table: "InstitutePlans");

            migrationBuilder.DropIndex(
                name: "IX_InstituteMemberNotes_UserId",
                table: "InstituteMemberNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InstituteMemberNotes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3823), new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3919), new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3922), new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3923) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3925), new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3925) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3928), new DateTime(2024, 6, 5, 1, 32, 26, 856, DateTimeKind.Utc).AddTicks(3928) });

            migrationBuilder.CreateIndex(
                name: "IX_InstitutePlans_InstituteId",
                table: "InstitutePlans",
                column: "InstituteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InstitutePlans_InstituteId",
                table: "InstitutePlans");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "InstituteMemberNotes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InstitutePlans_InstituteId_PlanId",
                table: "InstitutePlans",
                columns: new[] { "InstituteId", "PlanId" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(4940), new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5029), new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5032), new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5034), new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5037), new DateTime(2022, 11, 29, 18, 17, 28, 485, DateTimeKind.Utc).AddTicks(5037) });

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberNotes_UserId",
                table: "InstituteMemberNotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMemberNotes_Users_UserId",
                table: "InstituteMemberNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
