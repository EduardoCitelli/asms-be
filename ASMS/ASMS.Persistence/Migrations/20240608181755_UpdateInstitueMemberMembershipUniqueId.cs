using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class UpdateInstitueMemberMembershipUniqueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_InstituteMemberMemberships_InstituteMemberId_MembershipId",
                table: "InstituteMemberMemberships");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InstituteMemberMemberships_InstituteMemberId_MembershipId_StartDate",
                table: "InstituteMemberMemberships",
                columns: new[] { "InstituteMemberId", "MembershipId", "StartDate" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(205), new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(207) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(309), new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(312), new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(314), new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(315) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(317), new DateTime(2024, 6, 8, 18, 17, 54, 882, DateTimeKind.Utc).AddTicks(317) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_InstituteMemberMemberships_InstituteMemberId_MembershipId_StartDate",
                table: "InstituteMemberMemberships");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InstituteMemberMemberships_InstituteMemberId_MembershipId",
                table: "InstituteMemberMemberships",
                columns: new[] { "InstituteMemberId", "MembershipId" });

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
        }
    }
}
