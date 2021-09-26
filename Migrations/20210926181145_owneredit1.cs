using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Migrations
{
    public partial class owneredit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Garages_GarageId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_GarageId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "Owners");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Garages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_OwnerId",
                table: "Garages",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Owners_OwnerId",
                table: "Garages",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Owners_OwnerId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_OwnerId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Garages");

            migrationBuilder.AddColumn<Guid>(
                name: "GarageId",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_GarageId",
                table: "Owners",
                column: "GarageId",
                unique: true,
                filter: "[GarageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Garages_GarageId",
                table: "Owners",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
