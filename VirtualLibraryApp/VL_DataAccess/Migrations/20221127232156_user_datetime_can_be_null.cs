using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VL_DataAccess.Migrations
{
    public partial class user_datetime_can_be_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "LibraryUserId",
                table: "BookReviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_LibraryUserId",
                table: "BookReviews",
                column: "LibraryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_LibraryUserId",
                table: "BookReviews",
                column: "LibraryUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_LibraryUserId",
                table: "BookReviews");

            migrationBuilder.DropIndex(
                name: "IX_BookReviews_LibraryUserId",
                table: "BookReviews");

            migrationBuilder.DropColumn(
                name: "LibraryUserId",
                table: "BookReviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
