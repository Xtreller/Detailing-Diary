using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Data.Migrations
{
    public partial class Jobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DetailName",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "Jobs",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DetailName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Jobs");
        }
    }
}
