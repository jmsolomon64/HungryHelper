using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHelper.Data.Migrations
{
    public partial class UserProfileShoppingListFKAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "ShoppingList");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingList",
                newName: "OwnerId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UtcAdded",
                table: "ShoppingList",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UtcModified",
                table: "ShoppingList",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_OwnerId",
                table: "ShoppingList",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_UserProfile_OwnerId",
                table: "ShoppingList",
                column: "OwnerId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_UserProfile_OwnerId",
                table: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_OwnerId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "UtcAdded",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "UtcModified",
                table: "ShoppingList");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ShoppingList",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "ShoppingList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
