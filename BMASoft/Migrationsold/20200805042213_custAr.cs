using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class custAr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArCustId",
                table: "ArTransHs",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArTransHs_ArCusts_ArCustId",
                table: "ArTransHs");

            migrationBuilder.DropIndex(
                name: "IX_ArTransHs_ArCustId",
                table: "ArTransHs");

            migrationBuilder.DropColumn(
                name: "ArCustId",
                table: "ArTransHs");
        }
    }
}
