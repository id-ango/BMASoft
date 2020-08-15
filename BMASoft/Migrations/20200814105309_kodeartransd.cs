using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class kodeartransd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Kode",
                table: "ArTransHs",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kode",
                table: "ArTransDs",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kode",
                table: "ArTransDs");

            migrationBuilder.AlterColumn<string>(
                name: "Kode",
                table: "ArTransHs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
