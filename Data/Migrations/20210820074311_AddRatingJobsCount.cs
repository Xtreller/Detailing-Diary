using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Data.Migrations
{
    public partial class AddRatingJobsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobsCount",
                table: "Garages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Garages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobsCount",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Garages");
        }
    }
}
