﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Detailing_Diary.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Garage",
                table: "Jobs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Garage",
                table: "Jobs");
        }
    }
}
