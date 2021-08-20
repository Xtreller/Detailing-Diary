using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Data.Migrations
{
    public partial class ClientDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientCar",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientFirstName",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientLastName",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCar",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClientFirstName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClientLastName",
                table: "Jobs");
        }
    }
}
