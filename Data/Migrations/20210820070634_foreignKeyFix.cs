using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Data.Migrations
{
    public partial class foreignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Garages_GarageId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_AspNetUsers_OwnerId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_OwnerId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GarageId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GarageId1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Garages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Garages",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeerId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_OwnerId1",
                table: "Garages",
                column: "OwnerId1");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_AspNetUsers_OwnerId1",
                table: "Garages",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Garages_GarageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_AspNetUsers_OwnerId1",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_OwnerId1",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GarageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Garages");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Garages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "GarageId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeerId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GarageId1",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_OwnerId",
                table: "Garages",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GarageId1",
                table: "AspNetUsers",
                column: "GarageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Garages_GarageId1",
                table: "AspNetUsers",
                column: "GarageId1",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_AspNetUsers_OwnerId",
                table: "Garages",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
