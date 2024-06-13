using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class AddActivityQuantityToMembershipAndAddRemainingClassesToMemberMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_InstituteMemberActivities_InstituteMemberId_ActivityId",
                table: "InstituteMemberActivities");

            migrationBuilder.RenameColumn(
                name: "LastPaymentDate",
                table: "InstituteMemberMemberships",
                newName: "LastFullPaymentDate");

            migrationBuilder.AddColumn<int>(
                name: "ActivityQuantity",
                table: "Memberships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemainingClasses",
                table: "InstituteMemberMemberships",
                type: "int",
                nullable: true);

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
                name: "IX_InstituteMemberActivities_InstituteMemberId",
                table: "InstituteMemberActivities",
                column: "InstituteMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InstituteMemberActivities_InstituteMemberId",
                table: "InstituteMemberActivities");

            migrationBuilder.DropColumn(
                name: "ActivityQuantity",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "RemainingClasses",
                table: "InstituteMemberMemberships");

            migrationBuilder.RenameColumn(
                name: "LastFullPaymentDate",
                table: "InstituteMemberMemberships",
                newName: "LastPaymentDate");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InstituteMemberActivities_InstituteMemberId_ActivityId",
                table: "InstituteMemberActivities",
                columns: new[] { "InstituteMemberId", "ActivityId" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(5923), new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(5926) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6026), new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6030), new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6034), new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6037), new DateTime(2024, 6, 8, 19, 33, 20, 662, DateTimeKind.Utc).AddTicks(6038) });
        }
    }
}
