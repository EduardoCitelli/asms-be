using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class MemberShipTypeHaveInstitute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InstituteId",
                table: "MembershipTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_MembershipTypes_InstituteId",
                table: "MembershipTypes",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipTypes_Institutes_InstituteId",
                table: "MembershipTypes",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembershipTypes_Institutes_InstituteId",
                table: "MembershipTypes");

            migrationBuilder.DropIndex(
                name: "IX_MembershipTypes_InstituteId",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "MembershipTypes");
        }
    }
}