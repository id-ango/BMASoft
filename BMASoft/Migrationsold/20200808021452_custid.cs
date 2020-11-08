using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class custid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs");

            migrationBuilder.AlterColumn<int>(
                name: "ArCustId",
                table: "ArTransHs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs",
                column: "ArCustId",
                principalTable: "ArCusts",
                principalColumn: "ArCustId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs");

            migrationBuilder.AlterColumn<int>(
                name: "ArCustId",
                table: "ArTransHs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs",
                column: "ArCustId",
                principalTable: "ArCusts",
                principalColumn: "ArCustId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
