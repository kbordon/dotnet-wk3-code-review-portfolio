using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class AddUserIdToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_UserId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "comments");
        }
    }
}
