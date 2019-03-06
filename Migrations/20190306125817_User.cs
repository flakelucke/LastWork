using Microsoft.EntityFrameworkCore.Migrations;

namespace LastWork.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Instructions",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Instructions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_UserId",
                table: "Instructions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_UserId",
                table: "Instructions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Instructions",
                newName: "CreatorId");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Instructions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
