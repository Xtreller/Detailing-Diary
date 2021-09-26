using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Migrations
{
    public partial class oldOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_AspNetUsers_OwnerId",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Owners_OwnerId1",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_OwnerId1",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Garages");

            migrationBuilder.AddColumn<Guid>(
                name: "GarageId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GarageId",
                table: "AspNetUsers",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Garages_GarageId",
                table: "AspNetUsers",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AspNetUsers_Garages_GarageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Owners_OwnerId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GarageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId1",
                table: "Garages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_OwnerId1",
                table: "Garages",
                column: "OwnerId1",
                unique: true,
                filter: "[OwnerId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_AspNetUsers_OwnerId",
                table: "Garages",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Owners_OwnerId1",
                table: "Garages",
                column: "OwnerId1",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
