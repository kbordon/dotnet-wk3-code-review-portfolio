using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class ChangeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "posts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "comments",
                newName: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "comments",
                newName: "Id");
        }
    }
}
