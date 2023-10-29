using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    public partial class solvingSQLConflict6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CoverTypeId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CoverTypes_CoverTypeId",
                table: "Products",
                column: "CoverTypeId",
                principalTable: "CoverTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CoverTypes_CoverTypeId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CoverTypeId",
                table: "Products",
                column: "CoverTypeId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
