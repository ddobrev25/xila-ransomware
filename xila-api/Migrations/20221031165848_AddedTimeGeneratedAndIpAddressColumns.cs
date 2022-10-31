using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xila_api.Migrations
{
    public partial class AddedTimeGeneratedAndIpAddressColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "GeneratedKeyRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeGenerated",
                table: "GeneratedKeyRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "GeneratedKeyRecords");

            migrationBuilder.DropColumn(
                name: "TimeGenerated",
                table: "GeneratedKeyRecords");
        }
    }
}
