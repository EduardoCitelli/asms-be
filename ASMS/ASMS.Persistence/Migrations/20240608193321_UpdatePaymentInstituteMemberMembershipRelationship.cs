using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class UpdatePaymentInstituteMemberMembershipRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMemberMemberships_Payments_PaymentId",
                table: "InstituteMemberMemberships");

            migrationBuilder.DropIndex(
                name: "IX_InstituteMemberMemberships_PaymentId",
                table: "InstituteMemberMemberships");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "InstituteMemberMemberships");

            migrationBuilder.AddColumn<long>(
                name: "InstituteMemberMembershipId",
                table: "Payments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaymentDate",
                table: "InstituteMemberMemberships",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InstituteMemberMembershipId",
                table: "Payments",
                column: "InstituteMemberMembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_InstituteMemberMemberships_InstituteMemberMembershipId",
                table: "Payments",
                column: "InstituteMemberMembershipId",
                principalTable: "InstituteMemberMemberships",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_InstituteMemberMemberships_InstituteMemberMembershipId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InstituteMemberMembershipId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InstituteMemberMembershipId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LastPaymentDate",
                table: "InstituteMemberMemberships");

            migrationBuilder.AddColumn<long>(
                name: "PaymentId",
                table: "InstituteMemberMemberships",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMemberMemberships_PaymentId",
                table: "InstituteMemberMemberships",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMemberMemberships_Payments_PaymentId",
                table: "InstituteMemberMemberships",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
