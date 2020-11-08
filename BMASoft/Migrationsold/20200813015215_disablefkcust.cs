using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class disablefkcust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs");

            migrationBuilder.DropIndex(
                name: "IX_ArTransHs_ArCustId",
                table: "ArTransHs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArTransHs_ArCustId",
                table: "ArTransHs",
                column: "ArCustId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs",
                column: "ArCustId",
                principalTable: "ArCusts",
                principalColumn: "ArCustId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
