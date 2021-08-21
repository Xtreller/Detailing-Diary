using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Data.Migrations
{
    public partial class CascadeDeletion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Garages_GarageId",
                table: "Jobs");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Garages_GarageId",
                table: "Jobs",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Garages_GarageId",
                table: "Jobs");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Garages_GarageId",
                table: "Jobs",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
