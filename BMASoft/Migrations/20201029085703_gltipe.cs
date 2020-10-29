using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class gltipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipeGl",
                table: "GlAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipeGl",
                table: "GlAccounts");
        }
    }
}
