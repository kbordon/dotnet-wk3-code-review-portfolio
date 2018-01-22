using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class RemovePostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
