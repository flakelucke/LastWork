﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LastWork.Migrations
{
    public partial class DeleteBehaviorSetNull2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
                table: "Instructions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_AspNetUsers_UserId",
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
