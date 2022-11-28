using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VL_DataAccess.Migrations
{
    public partial class nav_prop_User_in_booReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_LibraryUserId",
                table: "BookReviews");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryUserId",
                table: "BookReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_LibraryUserId",
                table: "BookReviews",
                column: "LibraryUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_LibraryUserId",
                table: "BookReviews");

            migrationBuilder.AlterColumn<Guid>(
                name: "LibraryUserId",
                table: "BookReviews",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_LibraryUserId",
                table: "BookReviews",
                column: "LibraryUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
