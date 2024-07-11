using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMS.Persistence.Migrations
{
    public partial class AddDayOfWeekToClassBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "InstituteClassBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "InstituteClassBlocks");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5524), new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5525) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5650), new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5654), new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5655) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5658), new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5658) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5661), new DateTime(2024, 7, 10, 22, 24, 2, 992, DateTimeKind.Utc).AddTicks(5661) });
        }
    }
}
