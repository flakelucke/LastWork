using Microsoft.EntityFrameworkCore.Migrations;

namespace LastWork.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Instructions",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Instructions");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
