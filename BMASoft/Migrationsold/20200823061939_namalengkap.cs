﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class namalengkap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamaLengkap",
                table: "ArCusts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamaLengkap",
                table: "ArCusts");
        }
    }
}